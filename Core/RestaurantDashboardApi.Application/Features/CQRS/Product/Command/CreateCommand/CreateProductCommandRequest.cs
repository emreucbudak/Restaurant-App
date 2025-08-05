using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Product.Command.CreateCommand
{
    public class CreateProductCommandRequest : IRequest
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public int RestaurantId { get; set; }
    }
}
