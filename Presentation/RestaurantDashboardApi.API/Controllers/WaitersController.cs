using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Waiter.Command.DeleteCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Waiter.Command.UpdateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Waiter.Command.UpdateCommand.WaiterWorkStatusUpdate;
using RestaurantDashboardApi.Application.Features.CQRS.Waiter.Queries;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;

namespace RestaurantDashboardApi.API.Controllers
{
    [Authorize(Roles ="SystemAdmin,Waiter,RestaurantCase")]
    [Route("api/[controller]")]
    [ApiController]
    public class WaitersController : ControllerBase
    {
        private readonly IMediator _context;

        public WaitersController(IMediator context)
        {
            _context = context;
        }

        // GET: api/Waiters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Waiter>>> GetWaiters(int RestaurantId)
        {
            GetAllWaiterCommandRequest request = new() { RestaurantId = RestaurantId};  
            
            return Ok(await _context.Send(request));
        }




        [HttpPut("Email")]
        public async Task<IActionResult> PutWaiterWorkStatus([FromBody] string email)
        {
            UpdateWaiterWorkStatusRequest upt = new() { Email = email };

            await _context.Send(upt);
            return NoContent();
        }


        // DELETE: api/Waiters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaiter(DeleteWaiterCommandRequest dlt)
        {
            await _context.Send(dlt);
  

            return NoContent();
        }


    }
}
