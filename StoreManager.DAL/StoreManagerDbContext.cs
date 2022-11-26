using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManager.DAL.Entities;
using StoreManager.DAL.EntitiesConfiguration;

namespace StoreManager.DAL
{
    public class StoreManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        public StoreManagerDbContext(DbContextOptions<StoreManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<UsersStore> UsersStores { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<EmployeeSchedule> EmployeesSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseLazyLoadingProxies();
        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<UsersStore>().HasOne(x => x.User).WithOne(x => x.UsersStore).HasForeignKey<UsersStore>(x => x.StoreId);
            //builder.Entity<EmployeeSchedule>().HasOne(x => x.User).WithOne(x => x.EmployeeSchedule).HasForeignKey<EmployeeSchedule>(x => x.UserId);  
            builder.ApplyConfiguration(new IdentityUserLoginEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new SalaryEntityConfiguration());
            builder.ApplyConfiguration(new UsersStoreEntityConfiguration());
        }
    }
}
