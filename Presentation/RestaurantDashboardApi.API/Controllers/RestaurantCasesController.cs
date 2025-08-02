using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Command.CreateRestaurantCaseCommand;
using RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Queries.GetAllCaseCommand;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;

namespace RestaurantDashboardApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantCasesController : ControllerBase
    {
        private readonly IMediator _context;

        public RestaurantCasesController(IMediator context)
        {
            _context = context;
        }

        // GET: api/RestaurantCases
        [Authorize(Roles ="Waiter")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantCase>>> GetRestaurantsCase()
        {
            var getAll =  await _context.Send(new GetAllRestaurantCaseCommandRequest());
            return Ok(getAll);
        }



        // POST: api/RestaurantCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantCase>> PostRestaurantCase(CreateRestaurantCaseCommandRequest restaurantCase)
        {
            await _context.Send(restaurantCase);
            return Ok();
        }


    }
}
