using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using miniStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.Data.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");

            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        }
    }
}
