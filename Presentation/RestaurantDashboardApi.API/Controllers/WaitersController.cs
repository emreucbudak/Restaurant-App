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
using RestaurantDashboardApi.Application.Features.CQRS.Waiter.Queries;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;

namespace RestaurantDashboardApi.API.Controllers
{
    [Authorize(Roles ="RestaurantCase , SystemAdmin")]
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
        public async Task<ActionResult<IEnumerable<Waiter>>> GetWaiters(GetAllWaiterCommandRequest req)
        {

            return Ok(await _context.Send(req));
        }



        // PUT: api/Waiters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaiter(UpdateWaiterCommandHandler upt)
        {

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
