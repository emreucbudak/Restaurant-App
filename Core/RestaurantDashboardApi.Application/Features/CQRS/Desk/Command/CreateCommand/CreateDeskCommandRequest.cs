using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.CreateCommand
{
    public class CreateDeskCommandRequest : IRequest
    {
        public string DeskName { get; set; }
        public int RestaurantId { get; set; }
        public bool IsFull { get; set; } = false;
    }
}
