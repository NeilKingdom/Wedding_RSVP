using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;

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

         // AddDefaultIdentity() sets up token providers and configures authorization to use identity cookies
         services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<WeddingDbContext>().AddDefaultTokenProviders();

         // OAuth 2.0 Google authentication
         services.AddAuthentication().AddGoogle(googleOptions => {
            googleOptions.ClientId = configuration.GetValue<string>("Authentication:Google:ClientId");
            googleOptions.ClientSecret = configuration.GetValue<string>("Authentication:Google:ClientSecret");
         });

         // Setup authorization for RESTful API endpoints with Auth0 and JWT
//         services.AddAuthentication(options =>
//         {
//            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//         }).AddJwtBearer(options =>
//            {
//               options.Authority = $"https://{configuration["Auth0:Domain"]}/";
//               options.Audience = configuration["Auth0:Audience"];
//            }
//         );
//
//         // Generate SwaggerUI. Authorization occurs through here with the help of Auth0.
//         services.AddSwaggerGen(c => {
//            c.SwaggerDoc("v2", new OpenApiInfo { Title = "Wedding RSVP API", Version = "v2" });
//            c.ResolveConflictingActions(x => x.First());
//
//            var securitySchema = new OpenApiSecurityScheme
//            {
//               Description = "Using the Authorization header with the Bearer scheme.",
//               Name = "Authorization",
//               In = ParameterLocation.Header,
//               Type = SecuritySchemeType.Http,
//               Scheme = "bearer",
//               Reference = new OpenApiReference
//               {
//                  Type = ReferenceType.SecurityScheme,
//                  Id = "Bearer"
//               }
//            };
//
//            c.AddSecurityDefinition("Bearer", securitySchema);
//            c.AddSecurityRequirement(new OpenApiSecurityRequirement
//            {
//               { securitySchema, new[] { "Bearer" }}
//            });
//         });

         // Enable MVC support
         services.AddMvc().AddSessionStateTempDataProvider();
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

         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
         }
         else
         {
             app.UseDeveloperExceptionPage();
         }

//         app.UseSwagger(c => {
//            c.RouteTemplate = "swagger/{documentName}/swagger.json";
//         });
//         app.UseSwaggerUI(c => {
//            c.SwaggerEndpoint("/swagger/v2/swagger.json", "Wedding RSVP API");
//            c.RoutePrefix = "api";
//         });

         app.UseHsts();
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseSession();
         app.UseAuthentication();
         app.UseAuthorization();
         app.MapDefaultControllerRoute();

         app.Run();
      }
   }
}
