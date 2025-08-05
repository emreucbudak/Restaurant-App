using RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries
{
    public class GetAllOrderQueriesResponse
    {
        public int Id   { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan? UpdatedAt { get; set; }
        public List<ProductInfoDTO> Products { get; set; }
        public int TotalPrice { get; set; }
        public string OrderStatusName { get; set; }
        public int WaiterId     { get; set; }
        public string WaiterName { get;set; }
        public string DeskName { get; set; }
        public string OrderNotes { get; set; }
    }
}
