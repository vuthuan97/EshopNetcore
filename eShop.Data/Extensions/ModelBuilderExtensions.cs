using eShop.Data.Entites;
using eShop.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Data.Extensions
{
  public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "this home page of eshopsolution" },
               new AppConfig() { Key = "HomeKeyWord", Value = "this key word of eshopsolution" },
               new AppConfig() { Key = "HomeDescription", Value = "this description of eshopsolution" }

               );
            modelBuilder.Entity<Language>().HasData(
                new Language() {Id="vi-VN",Name="Tiếng Việt",IsDefault=true},
                new Language() { Id = "en-US", Name = "English", IsDefault = false });
            modelBuilder.Entity<Category>().HasData(
                new Category() {
                    Id=1,
                    IsShowOnHome=true,
                    ParentId=null,
                    SortOrder=1,
                    Status= Status.Active,
                },
                new Category()
                {   Id=2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active,
                   
                });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new CategoryTranslation() { Id = 1, CategoryId =1, Name = "Áo Nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoTitle = "Áo Thời Trang Nam", SeoDescription = "Sản Phẩm Áo Thời Trang Nam" },
                 new CategoryTranslation() { Id = 2, CategoryId =1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoTitle = "The Shirt Product Of Men", SeoDescription = "The Shirt Product Of Men" },
                 new CategoryTranslation() { Id = 3, CategoryId =2, Name = "Áo Nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoTitle = "Áo Thời Trang Nữ", SeoDescription = "Sản Phẩm Áo Thời Trang Nữ" },
                 new CategoryTranslation() { Id = 4, CategoryId =2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoTitle = "The Shirt Product Of Women", SeoDescription = "The Shirt Product Of Women" }

                 );
            modelBuilder.Entity<Product>().HasData(
               new Product()
               {  
                   Id=1,
                   DateCreate = DateTime.Now,
                   OriginalPrice=100000,
                   Price=2000000,
                   Stock= 0,
                   ViewCount=0,
               });
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {      Id=1,
                       ProductId=1,
                       Name = "Áo Sơ Mi Nam Trắng Việt Tiến",
                       LanguageId = "vi-VN",
                       SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                       SeoTitle = "Áo Sơ Mi Nam Trắng Việt Tiến",
                       SeoDescription = "Áo Sơ Mi Nam Trắng Việt Tiến",
                       Details = "Áo Sơ Mi Nam Trắng Việt Tiến",
                       Description = "Áo Sơ Mi Nam Trắng Việt Tiến"
                },
                new ProductTranslation()
                {
                       Id=2,
                       ProductId=1,
                       Name = "Viet Tien Men T-Shirt",
                       LanguageId = "en-US",
                       SeoAlias = "viet-tien-men-t-shirt",
                       SeoTitle = "Viet Tien Men T-Shirt",
                       SeoDescription = "Viet Tien Men T-Shirt",
                       Details = "Viet Tien Men T-Shirt",
                       Description = "Viet Tien Men T-Shirt"
                });
            modelBuilder.Entity<ProductInCategory>().HasData(
                 new ProductInCategory() { CategoryId = 1, ProductId = 1 }
                );


            // any guid
            var roleId = new Guid("50154AA5-4637-48C6-9108-2517E8D8227D");
            var adminId = new Guid("DC81385A-F5BC-4494-B888-DEC3C000702A");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Desription = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "vuthuan1997ss@gmail.com",
                NormalizedEmail = "over191997@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Vu",
                LastName = "Thuan",
                Dob = new DateTime(2020, 04, 25)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
    
}
