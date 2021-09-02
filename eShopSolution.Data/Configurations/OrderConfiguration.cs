using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            
            builder.Property(x => x.ShipEmail).IsUnicode(false).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(500);
            builder.HasOne(t => t.AppUser).WithMany(tp => tp.Orders).HasForeignKey(tp => tp.UserID);

        }
    }
}
