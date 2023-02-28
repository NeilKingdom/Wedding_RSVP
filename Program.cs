using Wedding_RSVP.Data;
using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;

namespace Wedding_RSVP
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         // Use PostgreSQL via the Npgsql package for the DbContext
         var connection = builder.Configuration.GetConnectionString("DefaultConnection");
         builder.Services.AddDbContext<WeddingDbContext>(options => options.UseNpgsql(connection));

         // Required for Nginx
         builder.Services.Configure<ForwardedHeadersOptions>(options => {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
         });

         // AddDefaultIdentity() sets up token providers and configures authorization to use identity cookies
         builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<WeddingDbContext>().AddDefaultTokenProviders();

         // OAuth 2.0 Google authentication
         builder.Services.AddAuthentication().AddGoogle(googleOptions => {
            googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
         });

         // Setup authorization for RESTful API endpoints with Auth0 and JWT
//         builder.Services.AddAuthentication(options =>
//         {
//            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//         }).AddJwtBearer(options =>
//            {
//               options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
//               options.Audience = builder.Configuration["Auth0:Audience"];
//            }
//         );
//
//         // Generate SwaggerUI. Authorization occurs through here with the help of Auth0.
//         builder.Services.AddSwaggerGen(c => {
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
         builder.Services.AddMvc().AddSessionStateTempDataProvider();
         builder.Services.AddSession();

         builder.Services.AddControllersWithViews();
         var app = builder.Build();

         // Seed the database 

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
            app.UseForwardedHeaders();
            app.UseHsts();
         }

//         app.UseSwagger(c => {
//            c.RouteTemplate = "swagger/{documentName}/swagger.json";
//         });
//         app.UseSwaggerUI(c => {
//            c.SwaggerEndpoint("/swagger/v2/swagger.json", "Wedding RSVP API");
//            c.RoutePrefix = "api";
//         });

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
