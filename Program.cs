using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Logging;

namespace Wedding_RSVP
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);
         var services = builder.Services;
         var configuration = builder.Configuration;

         // Use PostgreSQL via the Npgsql package for the DbContext
         var connection = configuration.GetConnectionString("DefaultConnection");
         services.AddDbContext<WeddingDbContext>(options => options.UseNpgsql(connection));

         // Required for Nginx
         services.Configure<ForwardedHeadersOptions>(options => {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
         });

         // Add MVC support 
         services.AddMvc();

         // Setup authorization for RESTful API endpoints with Auth0 and JWT
         services.AddAuthentication(options =>
         {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         }).AddJwtBearer(options => {
               options.Authority = configuration["Auth0:Authority"];
               options.Audience = configuration["Auth0:Audience"];
            }
         );

         // Generate SwaggerUI. Authorization occurs through here with the help of Auth0.
         services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wedding RSVP API", Version = "v1" });

            var securitySchema = new OpenApiSecurityScheme
            {
               Description = "Using the Authorization header with the Bearer scheme.",
               Name = "Authorization",
               In = ParameterLocation.Header,
               Type = SecuritySchemeType.Http,
               Scheme = "bearer",
               Reference = new OpenApiReference
               {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
               }
            };

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.AddSecurityDefinition("Bearer", securitySchema);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
               { securitySchema, new[] { "Bearer" }}
            });
         });

         IdentityModelEventSource.ShowPII = true;

         services.AddSession();
         services.AddControllersWithViews();
         var app = builder.Build();

         // Seed the database 

         using (var scope = app.Services.CreateScope())
         {
            var serviceProvider = scope.ServiceProvider;
            try
            {
               var context = serviceProvider.GetRequiredService<WeddingDbContext>();
               DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
               var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
               logger.LogError(ex, "An error occurred while seeding the database.");
            }
         }

         // Configure the HTTP request pipeline
         
         app.UseForwardedHeaders(); // NOTE: Make this first in the pipeline

         if (app.Environment.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
         }

         app.UseSwagger();
         app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wedding RSVP API");
            c.RoutePrefix = "api"; 
         });

         app.UseHsts();
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseSession();
         app.UseAuthentication();
         app.UseAuthorization();
         app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
         );

         app.Run();
      }
   }
}
