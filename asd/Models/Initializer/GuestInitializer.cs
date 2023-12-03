using asd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace asd.Models.Initializer
{
    internal static class GuestInitializer
    {
        public static void seedGuest(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(new Guest[]
            {
               new Guest { GuestID = 1, CompanyID = 1, Name = "Іван Василів" },
            new Guest { GuestID = 2, CompanyID = 1, Name = "Петро Симонович" },
            new Guest { GuestID = 3, CompanyID = 2, Name = "Василь Пупкін" },
            new Guest { GuestID = 4, CompanyID = 3, Name = "Сергій Іванов" },
            new Guest { GuestID = 5, CompanyID = 2, Name = "Роман Пушко" },
            new Guest { GuestID = 6, CompanyID = 1, Name = "Станіслав Мотужко" },
            new Guest { GuestID = 7, CompanyID = 2, Name = "Рустам Алекжі" }

            }
                );
        }
    }
}
