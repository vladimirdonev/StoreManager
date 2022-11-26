using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManager.DAL.EntitiesConfiguration
{
    public class IdentityUserLoginEntityConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProviderKey, x.LoginProvider });
        }
    }
}
