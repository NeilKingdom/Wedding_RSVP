using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Wedding_RSVP.Data
{
   public static class DbInitializer
   {
      public static void Initializer(WeddingDbContext context)
      {
         context.Database.EnsureCreated();

         if (context.User.Any())
         {
            return; // DB has been seeded
         }

         // Add users to DB
         var users = new List<User>
         {
            new User { FirstName="John",  LastName="Doe",   Email="john@example.com",  Attendees=1 }
         };

         foreach (User user in users)
         {
            context.User.Add(user);
         }

         context.SaveChanges();

         // Add Gifts to DB
         var gifts = new List<GiftRegistry>
         {
            new Gift { Desc="New Car",    Available=true }
         }

         foreach (Gift gift in gifts)
         {
            context.Gift.Add(gift);
         }

         context.SaveChanges();
      }
   }
}
