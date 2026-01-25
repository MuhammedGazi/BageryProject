namespace Bagery.Business.Features.Services.Queries.GetServiceById;

public record GetServiceByIdQueryResult(int ServiceId, string Title, string Description, string IconUrl);
