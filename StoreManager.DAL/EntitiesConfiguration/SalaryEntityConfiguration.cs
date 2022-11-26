using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.DAL.Entities;

namespace StoreManager.DAL.EntitiesConfiguration
{
    public class SalaryEntityConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EmployeeSalary).HasColumnType("decimal(10,2)");
            builder.HasOne(x => x.User).WithOne(x => x.EmployeeSalary).HasForeignKey<Salary>(x => x.UserId);
        }
    }
}
