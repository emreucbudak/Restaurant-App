using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Persistence.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(new ProductCategory()
            {
                Id = 1,
                CategoryName = "Kebaplar"
            },
            new ProductCategory()
            {
                Id= 2,
                CategoryName = "Ev Yemekleri"
            },
            new ProductCategory()
            {
                Id= 3,
                CategoryName = "Çorbalar"
            },
            new ProductCategory()
            {
                Id= 4,
                CategoryName = "Dönerler"
            },
            new ProductCategory()
            {
                Id = 5,
                CategoryName = "Ara Sıcaklar"
            },
            new ProductCategory()
            {
                Id= 6,
                CategoryName = "Sıcak İçecekler"
            },
            new ProductCategory ()
            {
                Id= 7,
                CategoryName = "Soğuk İçecekler"
            },
            new ProductCategory()
            {
                Id= 8,
                CategoryName = "Pideler"
            });
        }
    }
}
