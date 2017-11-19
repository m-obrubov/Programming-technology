using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        

        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ApplicationEntitiesDbContext : ApplicationIdentityDbContext
    {
        public new static ApplicationEntitiesDbContext Create()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationEntitiesDbContext>());
            return new ApplicationEntitiesDbContext();
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>().HasRequired(p => p.Address);
            modelBuilder.Entity<Buyer>().HasRequired(p => p.ShoppingCart);
            modelBuilder.Entity<Order>().HasRequired(p => p.ShoppingCart);
            base.OnModelCreating(modelBuilder);
        }
    }
}