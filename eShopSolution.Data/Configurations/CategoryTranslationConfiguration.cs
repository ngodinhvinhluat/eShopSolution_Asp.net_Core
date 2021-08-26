using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SeoDescription).HasMaxLength(200);

            builder.Property(x => x.SeoTitle).HasMaxLength(200);
            builder.Property(x => x.LanguageID).IsRequired().IsUnicode(false).HasMaxLength(5);
            builder.HasOne(t => t.Language).WithMany(tp => tp.CategoryTranslations).HasForeignKey(tp => tp.LanguageID);
            builder.HasOne(t => t.Category).WithMany(tp => tp.CategoryTranslations).HasForeignKey(tp => tp.CategoryID);

        }
    }
}
