using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Caption).HasMaxLength(200);

            builder.HasOne(t => t.Product).WithMany(tp => tp.ProductImages).HasForeignKey(tp => tp.ProductID);
        }
    }
}
