using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;

namespace MyStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<GroceryProducts> GroceryProduct { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GroceryCart> GroceryCart { get; set; }
        public DbSet<GroceryCartProducts> GroceryCartProducts { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder); 


            builder.Entity<Category>().HasKey(x => x.Name);
            builder.Entity<Category>().Property(x => x.DateCreated).HasDefaultValueSql("GetDate()");
            builder.Entity<Category>().Property(x => x.DateLastModified).HasDefaultValueSql("GetDate()");
            builder.Entity<Category>().Property(x => x.Name).HasMaxLength(100);

            builder.Entity<ApplicationUser>().HasOne(x => x.GroceryCart).WithOne(x => x.ApplicationUser).HasForeignKey<GroceryCart>(x => x.ApplicationUserID);
        }
    }
}
