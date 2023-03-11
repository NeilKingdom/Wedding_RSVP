using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore;

namespace Wedding_RSVP.Data
{
   public class WeddingDbContext : DbContext
   {
      public DbSet<UserCode> UserCodes { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Attendee> Attendees { get; set; }
      public DbSet<Gift> Gifts { get; set; }

      public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options)
      {}

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         // Rename tables
         modelBuilder.Entity<UserCode>().ToTable("UserCode");
         modelBuilder.Entity<User>().ToTable("User");
         modelBuilder.Entity<Attendee>().ToTable("Attendee");
         modelBuilder.Entity<Gift>().ToTable("Gift");
      }
   }
}
