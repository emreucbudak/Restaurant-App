using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Auth.Command.Register.Extensions
{
    public static class EntityFactory
    {
        public static (object Entity, Type EntityType) CreateEntity(string role, string name, string surname, string email, string password,int RestaurantId,string? PhoneNumber = null, int WaitWorkStatus = 1)
        {
            return role switch
            {
                "Waiter" => (new RestaurantDashboardApi.Domain.Entities.Waiter(name, surname, email, password,RestaurantId,PhoneNumber,WaitWorkStatus), typeof(RestaurantDashboardApi.Domain.Entities.Waiter)),
                "RestaurantCase" => (new RestaurantDashboardApi.Domain.Entities.RestaurantCase(name, surname, email, password,RestaurantId), typeof(RestaurantDashboardApi.Domain.Entities.RestaurantCase)),
                _ => throw new InvalidOperationException("Tür bulunamadı!")
            };
        }
    }
}
