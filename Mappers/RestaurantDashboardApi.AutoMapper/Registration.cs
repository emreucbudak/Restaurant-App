using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.AutoMapper
{
    public static class Registration
    {
        public static void RegisterMapper(this IServiceCollection services)
        {
            services.AddScoped<RestaurantDashboardApi.Application.Interfaces.AutoMappers.IAutoMapper, RestaurantDashboardApi.AutoMapper.Mapper>();
        }
    }
}
