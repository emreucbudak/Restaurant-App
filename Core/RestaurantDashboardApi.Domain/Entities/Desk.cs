using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class Desk : BaseEntity
    {
        public Desk(string deskName, int restaurantId, bool ısFull)
        {
            DeskName = deskName;
            RestaurantId = restaurantId;
            IsFull = ısFull;
        }
        public Desk()
        {

        }
        public string DeskName { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant {  get; set; }
        public bool IsFull { get; set; } = false;
        public ICollection<OrderItem> Items { get; set; }   
    }
}
