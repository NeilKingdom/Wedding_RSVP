using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore;

namespace Wedding_RSVP.Data
{
   public class WeddingDbContext : DbContext
   {
      public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options)
      {
      }

      public DbSet<UserInfo> Users { get; set; }
   }
}
