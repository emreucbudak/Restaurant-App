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
    public class WaiterWorkStatusConfiguration : IEntityTypeConfiguration<WaiterWorkStatus>
    {
        public void Configure(EntityTypeBuilder<WaiterWorkStatus> builder)
        {
            builder.HasData(new WaiterWorkStatus()
            {
                WaiterWorkStatusId = 1,
                WaiterWorkStatusName = "Aktif"
            },
            new WaiterWorkStatus()
            {
                WaiterWorkStatusId = 2,
                WaiterWorkStatusName = "İzinli"
            },
            new WaiterWorkStatus()
            {
                WaiterWorkStatusId = 3,
                WaiterWorkStatusName = "Molada"
            });
        }
    }
}
