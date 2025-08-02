using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Order.Command.CreateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.DeleteItemCommand;
using RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.Queries;
using RestaurantDashboardApi.Application.Features.CQRS.OrderItem.Command.UpdateItemCommand;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.API.Controllers
{
    [Authorize(Roles = "RestaurantCase, Waiter")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _context;

        public OrderItemsController(IMediator context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(GetAllOrderItemQueryRequest req)
        {
            return Ok(await _context.Send(req));
        }



        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(UpdateItemCommandRequest orderItem)
        {
            await _context.Send(orderItem);

            return NoContent();
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(CreateOrderItemCommandRequest orderItem)
        {
            await _context.Send(orderItem);
            return Ok();
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(DeleteItemCommandRequest id)
        {
            await _context.Send(id);
            return NoContent();
        }


    }
}
