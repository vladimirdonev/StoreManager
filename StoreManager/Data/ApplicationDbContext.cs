using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManager.Models;

namespace StoreManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<EmployeeSalary> EmployeesSalary { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<UsersStore> UsersStores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(10,2)");
            builder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.UserId,x.ProviderKey,x.LoginProvider});
            builder.Entity<EmployeeSalary>().Property(x => x.Salary).HasColumnType("decimal(10,2)");
            builder.Entity<EmployeeSalary>().HasKey(x => x.Id);
            builder.Entity<UsersStore>().HasKey(x => new { x.UserId, x.StoreId });
            builder.Entity<UsersStore>().HasOne(x => x.Store).WithMany(x => x.Users).HasForeignKey(x => x.StoreId);
            builder.Entity<UsersStore>().HasOne(x => x.User).WithMany(x => x.UsersStore).HasForeignKey(x => x.UserId);
        }
    }
}
