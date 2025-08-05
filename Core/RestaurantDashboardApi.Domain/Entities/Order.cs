using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderItems = new List<OrderItem>(); // varsayılan boş liste ataması
        }

        public Order(ICollection<OrderItem> items, int totalPrice, int orderStatusId, DateTime orderDate, int waiterId, int deskId)
        {
            OrderItems = items;
            TotalPrice = totalPrice;
            OrderStatusId = orderStatusId;
            OrderDate = orderDate;
            WaiterId = waiterId;
            DeskId = deskId;
        }

        public ICollection<OrderItem>? OrderItems { get; set; }
        public int TotalPrice { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public int WaiterId { get; set; }
        public Waiter Waiter { get; set; }
        public TimeSpan? UpdatedAt { get; set; }
        public string? OrderNote { get; set; }
        public bool IsCanceled { get; set; }
        public int DeskId { get; set; }
        public Desk Desk { get; set; }
        public bool IsHidden { get; set; } = false;
    }
}
