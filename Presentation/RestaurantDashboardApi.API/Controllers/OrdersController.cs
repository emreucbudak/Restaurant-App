using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.CreateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.DeleteCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.UpdateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Queries.GetAllQueries;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.API.Controllers
{
    [Authorize(Roles ="RestaurantCase, Waiter")]
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
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(GetAllOrderQueriesRequest gq)
        {
            return Ok(await _context.Send(gq));
        }


        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(UpdateOrderCommandRequest order)
        {
            await _context.Send(order);


            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(CreateOrderItemCommandHandler order)
        {
            await _context.Send(order);

            return Ok();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommandRequest id)
        {
            await _context.Send(id);

            return NoContent();
        }


    }
}
