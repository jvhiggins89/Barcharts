using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Workout495.Data;
using Workout495.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Workout495.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Text;

namespace Workout495
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Workout495Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<Workout495Context>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, Workout495Context>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IGoalsService, GoalService>();
            services.AddScoped<IProgressPointsService, ProgressPointService>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //make sure test user is there
            string key = ApplicationDbInitializer.SeedUsers(userManager);
            
            if(!string.IsNullOrEmpty(key))
            {
                //run sql command to associate orphan db entries with the test user
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var cmd = connection.CreateCommand();
                string cmdtext = @"UPDATE Goals SET UserId ='@#key' WHERE UserId is NULL; UPDATE Workout SET UserId ='@#key' WHERE UserId is NULL; UPDATE Exercise SET UserId ='@#key' WHERE UserId is NULL; UPDATE ProgressPoints SET UserID ='@#key' WHERE UserID is NULL;";

                StringBuilder sb = new StringBuilder(cmdtext);
                sb.Replace("@#key", key);
                cmd.CommandText = sb.ToString();
                cmd.ExecuteNonQuery();
            }
            
        }
    }
}
