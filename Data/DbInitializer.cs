using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Wedding_RSVP.Data
{
   public static class DbInitializer
   {
      public static void Initialize(WeddingDbContext context)
      {
         context.Database.EnsureCreated();

         if (context.Users.Any())
         {
            return; // DB has been seeded
         }

         // Add users to DB
         var users = new List<User>
         {
            new User { FirstName="John",  LastName="Doe",   Email="john@example.com",  NumAttendees=1 }
         };
         users.ForEach(user => context.Users.Add(user));
         context.SaveChanges();

         // Add Gifts to DB
         var gifts = new List<Gift>
         {
            new Gift {
               ImgUrl="~/img/thumbnails/car.jpg",
               SiteUrl="",
               Desc="New Car",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/car.jpg",
               SiteUrl="",
               Desc="New Car",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/car.jpg",
               SiteUrl="",
               Desc="New Car",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/car.jpg",
               SiteUrl="",
               Desc="New Car",
               Available=true
            }
         };
         gifts.ForEach(gift => context.Gifts.Add(gift));
         context.SaveChanges();
      }
   }
}
