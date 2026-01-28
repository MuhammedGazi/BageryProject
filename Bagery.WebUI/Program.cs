using Bagery.Business.Extensions;
using Bagery.Core.Entities;
using Bagery.DataAccess.Context;
using Bagery.DataAccess.Extensions;
using Bagery.WebUI.Middleware;
using Elastic.Apm.AspNetCore;
using Elastic.Apm.NetCoreAll;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

// Serilog konfigürasyonu
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithEnvironmentName()
    .Enrich.WithThreadId()
    .Enrich.WithExceptionDetails()
    .Enrich.WithProperty("Application", "MyMvcApp")
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
        new Uri(builder.Configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv8,
        IndexFormat = $"{builder.Configuration["ElasticConfiguration:DefaultIndex"]}-{DateTime.UtcNow:yyyy-MM}",
        NumberOfShards = 2,
        NumberOfReplicas = 1,
        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                          EmitEventFailureHandling.WriteToFailureSink |
                          EmitEventFailureHandling.RaiseCallback,
        FailureSink = new Serilog.Sinks.File.FileSink(
            "logs/elasticsearch-failures.txt",
            new Serilog.Formatting.Json.JsonFormatter(),
            null)
    })
    .WriteTo.File(
        "logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();
try
{
    Log.Information("Uygulama baþlatýlýyor...");

    builder.Host.UseSerilog();

    // Add services to the container.
    builder.Services.AddSession();
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddBusinessServices()
                    .AddDataAccessExt(builder.Configuration);

    builder.Services.AddIdentity<AppUser, AppRole>(options =>
    {
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;

        options.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<AppDbContext>();

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Elastic APM middleware (En üstte olmalý)
    app.UseAllElasticApm(builder.Configuration);

    // Serilog request logging
    app.UseSerilogRequestLogging(options =>
    {
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("UserName", httpContext.User.Identity?.Name ?? "Anonymous");
            diagnosticContext.Set("ClientIP", httpContext.Connection.RemoteIpAddress?.ToString());
            diagnosticContext.Set("UserAgent", httpContext.Request.Headers["User-Agent"].ToString());
        };
    });
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseSession();

    app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.UseAuthorization();

    app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Uygulama baþlatýlamadý");
}
finally
{
    Log.CloseAndFlush();
}