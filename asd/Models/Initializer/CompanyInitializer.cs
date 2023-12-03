using asd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace asd.Models.Initializer
{
    internal static class CompanyInitializer
    {
        public static void seedCompany(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Company>().HasData(new Company[]
            {
                new Company(){ CompanyID = 1, CompanyName = "ExpertSolution"},
                new Company(){ CompanyID = 2, CompanyName = "ServioSoft"},
                new Company(){ CompanyID = 3, CompanyName = "Apple"}
            }
                );
        }
    }
}
