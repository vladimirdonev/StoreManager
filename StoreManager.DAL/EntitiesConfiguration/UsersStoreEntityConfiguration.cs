using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManager.DAL.Entities;

namespace StoreManager.DAL.EntitiesConfiguration
{
    public class UsersStoreEntityConfiguration : IEntityTypeConfiguration<UsersStore>
    {
        public void Configure(EntityTypeBuilder<UsersStore> builder)
        {
            builder.HasKey(x => new { x.UserId, x.StoreId });
            builder.HasOne(x => x.Store).WithMany(x => x.Users).HasForeignKey(x => x.StoreId);
        }
    }
}
