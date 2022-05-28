using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAllApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookAllApp.Models;

namespace BookAllApp.Data
{
    public class BookAllAppContext : IdentityDbContext<BookAllAppUser>
    {
        public BookAllAppContext(DbContextOptions<BookAllAppContext> options)
            : base(options)
        {
        }

        public DbSet<BookAllApp.Models.Book> Book { get; set; }
        public DbSet<BookAllApp.Models.Order> Orders { get; set; }
        public DbSet<BookAllApp.Models.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
