using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using miniStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => new { x.OrderId, x.ProductId});

            builder.HasOne(o => o.Order ).WithMany(od=>od.OrderDetails).HasForeignKey(o => o.OrderId);
            builder.HasOne(p => p.Product).WithMany(od => od.OrderDetails).HasForeignKey(p => p.ProductId);
        }
    }
}
