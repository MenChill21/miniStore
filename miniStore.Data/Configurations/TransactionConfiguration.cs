using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using miniStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(a => a.AppUser).WithMany(t => t.Transactions ).HasForeignKey(a => a.UserId);

        }
    }
}
