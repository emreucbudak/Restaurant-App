using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(int orderId, int productId, int quantity, int totalPrice, int deskId)
        {
            OrderId = orderId;

            ProductId = productId;

            Quantity = quantity;
            TotalPrice = totalPrice;
            DeskId = deskId;

        }

        public int OrderId  { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int DeskId   { get; set; }
        public Desk Desk { get; set; }
    }
}
