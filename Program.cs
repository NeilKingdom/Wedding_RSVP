using Wedding_RSVP.Data;
using Microsoft.EntityFrameworkCore;

namespace Wedding_RSVP
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         // Add services to the container
         builder.Services.AddControllersWithViews();
         var connection = builder.Configuration.GetConnectionString("DefaultConnection");

         builder.Services.AddDbContext<WeddingDbContext>(options => options.UseSqlServer(connection));
         builder.Services.AddMvc().AddSessionStateTempDataProvider();
         builder.Services.AddSession();

         var app = builder.Build();

         /* Seed the database */
         using (var scope = app.Services.CreateScope())
         {
            var services = scope.ServiceProvider;
            try
            {
               var context = services.GetRequiredService<WeddingDbContext>();
               DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
               var logger = services.GetRequiredService<ILogger<Program>>();
               logger.LogError(ex, "An error occurred while seeding the database.");
            }
         }

         // Configure the HTTP request pipeline
         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
         }

         app.UseStaticFiles();
         app.UseRouting();
         app.UseSession();
         app.UseAuthorization();
         app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
         );

         app.Run();
      }
   }
}
