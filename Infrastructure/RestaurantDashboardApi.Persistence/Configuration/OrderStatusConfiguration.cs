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
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(new OrderStatus()
            {
                Id = 1,
                StatusName = "Onay Bekliyor"
            },
            new OrderStatus()
            {
                Id = 2,
                StatusName = "Hazırlanıyor"
            },
            new OrderStatus()
            {
                Id = 3,
                StatusName = "Hazırlandı"
            },
            new OrderStatus()
            {
                Id = 4,
                StatusName = "Ödeme Bekliyor"
            },
            new OrderStatus()
            {
                Id = 5,
                StatusName = "Ödeme Alındı"
            },
            new OrderStatus()
            {
                Id = 6,
                StatusName = "İptal Edildi"
            });
        }
    }
}
