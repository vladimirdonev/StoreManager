using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.DAL.Entities;

namespace StoreManager.DAL.EntitiesConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)");
        }
    }
}
