using System;
using BookAllApp.Areas.Identity.Data;
using BookAllApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BookAllApp.Areas.Identity.IdentityHostingStartup))]
namespace BookAllApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) =>
            //{
            //    services.AddDbContext<BookAllAppContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("BookAllAppContextConnection")));

            //    services.AddDefaultIdentity<BookAllAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<BookAllAppContext>();
            //});
        }
    }
}