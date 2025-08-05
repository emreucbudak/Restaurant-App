using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.CreateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.DeleteCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.DeleteCommand.DeleteWaiterOrder;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand.UpdateOrderStaus;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand.UpdateStatusOrderRequest;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries.GetUnConfirmedOrdersByWaiter;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetUnConfirmedOrders;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.API.Controllers
{
    [Authorize(Roles ="RestaurantCase,Waiter")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _context;

        public OrdersController(IMediator context)
        {
            _context = context;
        }

        // GET: api/Orders
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int RestaurantId)
        {
            GetUnConfirmedOrdersRequest gq = new() { RestaurantId = RestaurantId };
            return Ok(await _context.Send(gq));
        }
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersAll(int RestaurantId)
        {
            GetAllOrderQueriesRequest gq = new() { RestaurantId = RestaurantId };
            return Ok(await _context.Send(gq));
        }
        [HttpGet("unconfirmedwaiters")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int restaurantId,int waiterId)
        {
            GetWaiterUnConfirmedOrdersRequest gq = new();
            gq.RestaurantId = restaurantId;
            gq.WaiterId = waiterId; 
            return Ok(await _context.Send(gq));
        }


        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderAll(UpdateOrderCommandRequest order)
        {
            await _context.Send(order);


            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(CreateOrderItemCommandRequest order)
        {
            await _context.Send(order);

            return Ok();
        }

        // DELETE: api/Orders/5

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderWaiter(int id)
        {
            DeleteWaiterOrderRequest deleteWaiterOrderRequest = new DeleteWaiterOrderRequest { OrderId = id };
            await _context.Send(deleteWaiterOrderRequest);

            return NoContent();
        }
        [HttpPut("updatestatus")] 
        public async Task<IActionResult> PutOrder([FromBody] UpdateStatusRequest request)
        {

            await _context.Send(request);
            return NoContent();
        }


    }
}
