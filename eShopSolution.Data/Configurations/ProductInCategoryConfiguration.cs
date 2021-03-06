using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(t => new { t.CategoryID, t.ProductID });
            builder.ToTable("ProductInCategory");
            builder.HasOne(t => t.Product).WithMany(tp => tp.ProductInCategories).HasForeignKey(tp => tp.ProductID);
            builder.HasOne(t => t.Category).WithMany(tp => tp.ProductInCategories).HasForeignKey(tp => tp.CategoryID);

        }
    }
}
