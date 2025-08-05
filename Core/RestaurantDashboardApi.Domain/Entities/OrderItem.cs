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

        public OrderItem(int orderId, int productId, int quantity, int totalPrice)
        {
            OrderId = orderId;

            ProductId = productId;

            Quantity = quantity;
            TotalPrice = totalPrice;


        }



        public int OrderId { get; set; }
        public Order Order { get; set; }  // Order ile ilişki

        public int ProductId { get; set; }
        public Product Product { get; set; }  // Product ile ilişki

        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

    }
}
