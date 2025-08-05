using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
        }

        public Product(string productName, string productDescription, int productPrice, int productCategoryId, int restaurantId)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductCategoryId = productCategoryId;
            RestaurantId = restaurantId;

        }

        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }

        
        public int ProductPrice { get; set; }
        public int RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }



    }
}
