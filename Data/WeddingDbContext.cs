using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Wedding_RSVP.Data
{
   public class WeddingDbContext : IdentityDbContext<User>
   {
      public DbSet<User> MyUsers { get; set; }
      public DbSet<Attendee> Attendees { get; set; }
      public DbSet<Gift> Gifts { get; set; }

      public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options)
      {}

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder); // Required for mapping keys from Identity tables

         // Rename tables
         modelBuilder.Entity<User>().ToTable("User");
         modelBuilder.Entity<Attendee>().ToTable("Attendee");
         modelBuilder.Entity<Gift>().ToTable("Gift");
      }
   }
}
