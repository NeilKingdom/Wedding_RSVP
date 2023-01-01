using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore;

namespace Wedding_RSVP.Data
{
   public class WeddingDbContext : DbContext
   {
      public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options)
      {}

      public DbSet<User> Users { get; set; }
      public DbSet<Gift> Gifts { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<User>().ToTable("User");
         modelBuilder.Entity<Gift>().ToTable("Gift");

         // Determine the dependent entity for 1:1 relationship
         modelBuilder.Entity<User>()
            .HasOne(a => a.Gift)
            .WithOne(b => b.User)
            .HasForeignKey<Gift>(b => b.GiftRef);
      }
   }
}
