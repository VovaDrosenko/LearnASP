using asd.Models.Entities;
using asd.Models.Initializer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace asd.Models
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext() : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.seedGuest();
            builder.seedCompany();

        }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
