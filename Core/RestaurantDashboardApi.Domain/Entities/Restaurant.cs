using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class Restaurant : BaseEntity    
    {
        public Restaurant()
        {
        }

        public Restaurant(string restaurantName, int restaurantCaseId)
        {
            RestaurantName = restaurantName;
        }

        public string RestaurantName { get; set; }
        public ICollection<Desk>? Desks { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Waiter>? Waiters { get; set; }

    }
}
