using BookAllApp.Areas.Identity.Data;
using BookAllApp.Data;
using BookAllApp.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAllApp
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if(_env.IsStaging())
            {
                services.AddDbContext<BookAllAppContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("BookAllAppRemoteConnection")));
            }
            else
            {
                services.AddDbContext<BookAllAppContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("BookAllAppContextConnection")));
            }
            
            
            services.AddIdentity<BookAllAppUser, IdentityRole>(
                options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    //options.SignIn.RequireConfirmedEmail = false;
                    //options.SignIn.RequireConfirmedPhoneNumber = false;
                })
                //.AddDefaultUI()
                .AddEntityFrameworkStores<BookAllAppContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });


            // place for DI AddScoped
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddSession();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, RoleManager<IdentityRole> roleManager)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            // if before any registration of a user need to check the UPDATED roles then this should be a midd
            Task.Run(() => CreateAppRoles(roleManager)).Wait();
            
            app.UseAuthentication();
            app.UseAuthorization();

            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "books",
                    pattern: "books/{id?}",
                    defaults: new { controller = "Books", action = "Create" });
                endpoints.MapControllerRoute(name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
        }

        private async Task CreateAppRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var configItem in this.Configuration.GetSection("Roles").Get<List<string>>())
            {
                if (!await roleManager.RoleExistsAsync(configItem))
                {
                    await roleManager.CreateAsync(new IdentityRole(configItem));
                }
            }
        }
    }
}
