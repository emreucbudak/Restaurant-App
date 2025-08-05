using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.UpdateCommand
{
    public class UpdateDeskCommandRequest : IRequest
    {

        public string DeskName { get; set; }
        public bool IsFull { get; set; }
        public int  RestaurantId { get; set; }
    }
}
