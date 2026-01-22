using Bagery.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bagery.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ThreeStepService> ThreeStepServices { get; set; }
    }
}
