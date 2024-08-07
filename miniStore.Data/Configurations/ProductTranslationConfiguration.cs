using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using miniStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Details).HasMaxLength(500);

            builder.HasOne(p=> p.Product).WithMany(pt => pt.ProductTranslations).HasForeignKey(pt => pt.ProductId);
            builder.HasOne(l => l.Language).WithMany(pt => pt.ProductTranslations).HasForeignKey(pt => pt.LanguageId);

        }
    }
}
