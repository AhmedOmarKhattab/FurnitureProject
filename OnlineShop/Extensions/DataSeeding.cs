using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Extensions;
using OnlineShop.Models;

namespace BrightMinds.Api.Extensions
{
    public static class DataSeeding
    {
        public static async Task<WebApplication> SeedAppData(this WebApplication application, ApplicationDbContext context)
        {


            // 1. Seed Special Tags
            if (!context.specialTags.Any())
            {
                var specialTags = new List<SpecialTag>
                {
                    new SpecialTag { Name = "جديد" },
                    new SpecialTag { Name = "الأكثر مبيعًا" },
                    new SpecialTag { Name = "عرض خاص" },
                    new SpecialTag { Name = "مناسب للهدايا" }
                };
                await context.AddRangeAsync(specialTags);
                await context.SaveChangesAsync();
            }

            // 2. Seed Product Types (Toy Categories)
            if (!context.ProductTypes.Any())
            {
                var productTypes = new List<ProductType>
                 {
                     new ProductType { Name = "أثاث غرف المعيشة" },
                     new ProductType { Name = "أثاث غرف النوم" },
                     new ProductType { Name = "طاولات وكراسي الطعام" },
                     new ProductType { Name = "أثاث المكاتب المنزلية" },
                     new ProductType { Name = "وحدات التخزين والأرفف" }
                 };
                await context.ProductTypes.AddRangeAsync(productTypes);
                await context.SaveChangesAsync();
            }
            // 3. Seed Brands (Toy Brands)
            if (!context.productBrands.Any())
            {
                var brands = new List<ProductBrand>
    {
        new ProductBrand { Name = "مودرن هوم - Modern Home" },
        new ProductBrand { Name = "إيكيا - IKEA" },
        new ProductBrand { Name = "أشلي للأثاث - Ashley" },
        new ProductBrand { Name = "ناشيونال - National" },
        new ProductBrand { Name = "رويال ديزاين - Royal Design" }
    };
                await context.productBrands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }
            // 4. Seed Products (Kids Toys)
            if (!context.Products.Any())
            {
                var tagIds = await context.specialTags.Select(t => t.Id).ToListAsync();
                var brandIds = await context.productBrands.Select(t => t.Id).ToListAsync();
                var typeIds = await context.ProductTypes.Select(t => t.Id).ToListAsync();
                var random = new Random();

                var products = new List<Product>
    {
        new Product
        {
            Name = "أريكة مخملية ثلاثية",
            Price = 4500,
            Image = "image5.jpeg",
            ProductColor = "أزرق ملكي",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // غرف المعيشة
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "أريكة مريحة مبطنة بالإسفنج عالي الكثافة مع أرجل خشبية صلبة وتصميم عصري.",
            Quantity = 10
        },
        new Product
        {
            Name = "سرير مزدوج King Size",
            Price = 7200,
            Image = "image1.jpg",
            ProductColor = "بني جوزي",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // غرف النوم
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "إطار سرير مصنوع من خشب الزان الطبيعي، يتميز بظهر مبطن وتصميم كلاسيكي فاخر.",
            Quantity = 5
        },
        new Product
        {
            Name = "طاولة طعام خشبية مع 6 كراسي",
            Price = 5800,
            Image = "image2.jpg",
            ProductColor = "أبيض وبني",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // طاولات الطعام
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "طقم طعام متكامل يجمع بين المتانة والأناقة، مثالي للمساحات المتوسطة والكبيرة.",
            Quantity = 7
        },
        new Product
        {
            Name = "مكتب عمل زجاجي مودرن",
            Price = 1850,
            Image = "image3.jpg",
            ProductColor = "شفاف/أسود",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // مكاتب
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "مكتب أنيق بسطح من الزجاج المقوى وهيكل معدني مقاوم للصدأ، مناسب للعمل المنزلي.",
            Quantity = 15
        },
         new Product
        {
            Name = "مكتب عمل زجاجي مودرن",
            Price = 1850,
            Image = "image3.jpg",
            ProductColor = "شفاف/أسود",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // مكاتب
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "مكتب أنيق بسطح من الزجاج المقوى وهيكل معدني مقاوم للصدأ، مناسب للعمل المنزلي.",
            Quantity = 15
        },
          new Product
                 {
                     Name = "مكتب عمل زجاجي مودرن",
                     Price = 1850,
                     Image = "image3.jpg",
                     ProductColor = "شفاف/أسود",
                     IsAvailable = true,
                     SpecialTagId = tagIds[random.Next(tagIds.Count)],
                     ProductTypeId = typeIds[random.Next(typeIds.Count)], // مكاتب
                     ProductBrandId = brandIds[random.Next(brandIds.Count)],
                     Description = "مكتب أنيق بسطح من الزجاج المقوى وهيكل معدني مقاوم للصدأ، مناسب للعمل المنزلي.",
                     Quantity = 15
                 },
          new Product
        {
            Name = "مكتب عمل زجاجي مودرن",
            Price = 1850,
            Image = "image3.jpg",
            ProductColor = "شفاف/أسود",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // مكاتب
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "مكتب أنيق بسطح من الزجاج المقوى وهيكل معدني مقاوم للصدأ، مناسب للعمل المنزلي.",
            Quantity = 15
        },


        new Product
        {
            Name = "خزانة كتب جدارية",
            Price = 1200,
            Image = "image1.jpg",
            ProductColor = "رمادي فاتح",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // وحدات تخزين
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "وحدة أرفف متعددة الاستخدامات لتنظيم الكتب والتحف بشكل جمالي وعملي.",
            Quantity = 20
        },
        new Product
        {
            Name = "كرسي استرخاء (Recliner)",
            Price = 2400,
            Image = "image4.jpg",
            ProductColor = "بيج",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // غرف معيشة
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "كرسي هزاع ومتحرك يوفر أقصى درجات الراحة مع خاصية دعم الظهر والقدمين.",
            Quantity = 12
        },
          new Product
        {
            Name = "كرسي استرخاء (Recliner)",
            Price = 2100,
            Image = "image1.jpg",
            ProductColor = "بيج",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // غرف معيشة
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "كرسي هزاع ومتحرك يوفر أقصى درجات الراحة مع خاصية دعم الظهر والقدمين.",
            Quantity = 12
        },
            new Product
        {
            Name = "كرسي استرخاء (Recliner)",
            Price = 2100,
            Image = "image2.jpg",
            ProductColor = "بيج",
            IsAvailable = true,
            SpecialTagId = tagIds[random.Next(tagIds.Count)],
            ProductTypeId = typeIds[random.Next(typeIds.Count)], // غرف معيشة
            ProductBrandId = brandIds[random.Next(brandIds.Count)],
            Description = "كرسي هزاع ومتحرك يوفر أقصى درجات الراحة مع خاصية دعم الظهر والقدمين.",
            Quantity = 12
        }
    };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
            return application;
        }
    }
}