using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.CreateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.DeleteCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Desk.Command.UpdateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Desk.Queries;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;

namespace RestaurantDashboardApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesksController : ControllerBase
    {
        private readonly IMediator _context;

        public DesksController(IMediator context)
        {
            _context = context;
        }

        // GET: api/Desks
        [Authorize(Roles = "Waiter,RestaurantCase")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desk>>> GetDesks([FromQuery] int restaurantId)
        {
            var request = new GetAllDeskCommandRequest { RestaurantId = restaurantId };
            var getAllDesks = await _context.Send(request);
            return Ok(getAllDesks);
        }
        // PUT: api/Desks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutDesk(UpdateDeskCommandRequest request)
        {
            await _context.Send(request); // Değişkene atama yok

            return NoContent();
        }


        // POST: api/Desks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "RestaurantCase")]
        [HttpPost]
        public async Task<ActionResult<Desk>> PostDesk(CreateDeskCommandRequest desk)
        {
             await _context.Send(desk);

            return Ok();
        }

        // DELETE: api/Desks/5
        [Authorize(Roles = "RestaurantCase")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDesk(string nms)
        {
            DeleteDeskCommandRequest id = new() { Name = nms };
            await _context.Send(id);

            return Ok();


        }


    }
}
