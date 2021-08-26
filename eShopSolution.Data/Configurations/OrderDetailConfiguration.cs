using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => new { x.OrderID, x.ProductID });
            builder.HasOne(t => t.Order).WithMany(tp => tp.OrderDetail).HasForeignKey(tp => tp.OrderID);
            builder.HasOne(t => t.Product).WithMany(tp => tp.OrderDetails).HasForeignKey(tp => tp.ProductID);

        }
    }
}
