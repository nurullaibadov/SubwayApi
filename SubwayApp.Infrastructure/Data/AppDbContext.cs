using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubwayApp.Domain.Entities;

namespace SubwayApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
