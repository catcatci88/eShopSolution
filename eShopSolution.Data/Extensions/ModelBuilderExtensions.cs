using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Data Seeding
            modelBuilder.Entity<AppConfig>().HasData(
                //tạo ra 3 bản ghi
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name="Tiếng Việt", IsDefault = true},
                new Language() { Id = "en-US", Name="English", IsDefault = false}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                    {
                        Id = 1,
                        IsShowOnHome = true,
                        ParentId = null,
                        SortOrder = 1,
                        Status = Status.Active,
                    },
                new Category()
                    {
                        Id = 2,
                        IsShowOnHome = true,
                        ParentId = null,
                        SortOrder = 2,
                        Status = Status.Active,
                    }
                );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                    {
                        Id = 1,
                        CategoryId = 1,
                        Name = "Áo nam",
                        LanguageId = "vi-VN",
                        SeoAlias = "ao-nam",
                        SeoDescription = "Sản phẩm áo thời trang",
                        SeoTitle = "Sản phẩm áo thời trang"
                    },
                    new CategoryTranslation()
                    {
                        Id = 2,
                        CategoryId = 1,
                        Name = "Men Shirt",
                        LanguageId = "en-US",
                        SeoAlias = "men-shirt",
                        SeoDescription = "The shirt products of men",
                        SeoTitle = "The shirt products of men"
                    },
                    new CategoryTranslation()
                    {
                        Id = 3,
                        CategoryId = 2,
                        Name = "Áo nữ",
                        LanguageId = "vi-VN",
                        SeoAlias = "ao-nu",
                        SeoDescription = "Sản phẩm áo thời trang",
                        SeoTitle = "Sản phẩm áo thời trang"
                    },
                    new CategoryTranslation()
                    {
                        Id = 4,
                        CategoryId = 2,
                        Name = "Women Shirt",
                        LanguageId = "en-US",
                        SeoAlias = "women-shirt",
                        SeoDescription = "The shirt products of women",
                        SeoTitle = "The shirt products of women"
                    }
                );
            modelBuilder.Entity<Product>().HasData(
               new Product  ()
               {
                   Id = 1,
                   DataCreated = DateTime.Now,
                   OriginalPrice = 100000, 
                   Price = 200000, 
                   Stock = 0, 
                   ViewCount = 0,
               });
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Áo sơ mi trắng",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-so-mi-trang",
                    SeoDescription = "Áo sơ mi trắng",
                    SeoTitle = "Áo sơ mi trắng",
                    Details = "Áo sơ mi trắng",
                    Description = "Áo sơ mi trắng"
                },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Men T-Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "men-t-shirt",
                    SeoDescription = "Men T-Shirt",
                    SeoTitle = "Men T-Shirt",
                    Details = "Men T-Shirt",
                    Description = "Men T-Shirt"
                }
                );
            //
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );
            var roleId = new Guid("B3A585D5-8F8E-4D00-A3AC-EEC7E6C9F668");
            var adminId = new Guid("C804A3B6-0A82-431D-B1C1-238DC442B964");
            // any guid, but nothing is against to use the same one
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator"
                
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "chienboston@gmail.com",
                NormalizedEmail = "chienboston@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Chien",
                LastName = "Boston",
                Dob = new DateTime(2021,01,07)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
