using RestaurantDashboardApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Queries
{
    public class GetAllDeskCommandResponse 
    {
        public int Id { get; set; }
        public string DeskName { get; set; }
        public int RestaurantId { get; set; }
        public bool IsFull { get; set; } = false;
    }
}
