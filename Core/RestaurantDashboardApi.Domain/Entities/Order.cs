using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(ICollection<OrderItem> ıtems, int totalPrice, int orderStatusId, DateTime orderDate,int waiterId)
        {
            Items = ıtems;
            TotalPrice = totalPrice;
            OrderStatusId = orderStatusId;
            OrderDate = orderDate;
            WaiterId = waiterId;
 
        }

        public ICollection<OrderItem> Items { get; set; }
        public int TotalPrice { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus {  get; set; }
        public DateTime OrderDate { get; set; }
        public int WaiterId     { get; set; }
        public Waiter Waiter { get; set; }
        public TimeSpan? UpdatedAt { get; set; }

    }
}
