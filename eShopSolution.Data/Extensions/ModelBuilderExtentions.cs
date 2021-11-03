using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //data seeding
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is a home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is a keyword of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is a description of eShopSolution" }

                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { ID="vi-VN",Name="Tiếng Việt",IsDefault=true},
                new Language() { ID="en-US",Name="English",IsDefault=false}
                );
            modelBuilder.Entity<Category>().HasData(
                new Category() {ID=1, IsShowOnHome =true, ParentID =null,SortOrder=1,Status=Status.Active},
                new Category() {ID =2, IsShowOnHome = true, ParentID = null, SortOrder = 2,Status=Status.Active }
                );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() { Id =1,
                    CategoryID=1,
                    Name="Tai nghe",
                    LanguageID="vi-VN",
                    SeoAlias="tai-nghe",
                    SeoDescription="Tai nghe hiện đại jack kết nối 3.5",
                    SeoTitle="Tai nghe hiện đại"    
                },
                new CategoryTranslation()
                {
                    Id=2,
                    CategoryID=1,
                    Name= "Headphone",
                    LanguageID="en-US",
                    SeoAlias="headphone",
                    SeoDescription= " Modern headphones with jack connect 3.5",
                    SeoTitle="Modern headphone"
                },
                new CategoryTranslation()
                {
                    Id=3,
                    CategoryID=2,
                    Name= "Tai nghe bluetooth",
                    LanguageID="vi-VN",
                    SeoAlias="tai-nghe-bluetooth",
                    SeoDescription="Tai nghe không dây kết nối thông qua Bluetooth",
                    SeoTitle="Tai nghe không dây hiện đại kết nối Blutooth"
                },
                new CategoryTranslation()
                {
                    Id=4,
                    CategoryID=2,
                    Name="Bluetooth headphone",
                    LanguageID="en-US",
                    SeoAlias="bluetooth-headphone",
                    SeoDescription= "Wireless headphones connected via Bluetooth",
                    SeoTitle= "Modern wireless Bluetooth headset"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ID = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice=15000,
                    Price=100000,
                    Stock=0,
                    ViewCount=0,
                }
                );
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id=1,
                    ProductID=1,
                    Name="Tai nghe bluetooth Vivan",
                    LanguageID="vi-VN",
                    SeoAlias="tai-nghe-bluetooth-vivan",
                    SeoDescription="Tai nghe Bluetooth Vivan hiện đại sạc 2h dùng 6.5h",
                    SeoTitle= "Tai nghe Bluetooth Vivan hiện đại",
                    Detail= "Mua Tai Nghe Bluetooth TWS VIVAN Liberty T200 - Cảm Ứng - Playtime Đến 22H - Chống Nước IPX4 giá tốt. Mua hàng qua mạng uy tín, tiện lợi.",
                    Description= "Tai Nghe Bluetooth TWS VIVAN Liberty T200 - Cảm Ứng - Playtime Đến 22H "
                },
                new ProductTranslation()
                {
                    Id=2,
                    ProductID=1,
                    Name= "Vivan bluetooth headset",
                    LanguageID="en-US",
                    SeoAlias= "vivan-bluetooth-headset",
                    SeoDescription= "Modern Vivan Bluetooth headset charges for 2 hours and uses 6.5 hours",
                    SeoTitle="Modern Vivan Bluetooth headset",
                    Detail= "VIVAN Liberty T200 Bluetooth Headset - Touch - Playtime Up to 22H - IPX4 Waterproof at good price. Buy online reputable, convenient.",
                    Description= "VIVAN Liberty T200 Bluetooth Headset - Touch - Playtime Up to 22H ",
                }
                );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    ProductID=1,
                    CategoryID=2
                }
                );
            var AdminID = new Guid("2659D4C4-6BB0-48EA-9711-39B671DEB886");
            var RoleID = new  Guid("45284839-E929-4807-8C84-CB1CF81CDCDF");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = RoleID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = AdminID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "ngodinhvinhluat@gmail.com",
                NormalizedEmail = "ngodinhvinhluat@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Vl1998@"),
                SecurityStamp = string.Empty,
                FullName = "Toan",
                BoD = new DateTime(1998, 04, 03)
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = RoleID,
                UserId = AdminID
            });
        }
    }
}
