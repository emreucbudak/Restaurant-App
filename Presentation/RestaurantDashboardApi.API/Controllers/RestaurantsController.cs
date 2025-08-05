using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.CreateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.DeleteCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Command.DeleteCommand.DeleteProductFromRestaurant;
using RestaurantDashboardApi.Application.Features.CQRS.Restaurant.Queries.GetAllQueries.RestaurantFoods;
using RestaurantDashboardApi.Application.Features.CQRS.RestaurantCase.Queries.GetAllCaseCommand;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.API.Controllers
{
    [Authorize(Roles = "Waiter,RestaurantCase")]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator _context;

        public RestaurantsController(IMediator context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants(GetAllRestaurantCaseCommandRequest req)
        {

            return Ok(await _context.Send(req));
        }

        [HttpGet("getproductsbycategories")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurantsFood(int Id)
        {
            GetAllFoodsFromRestaurantRequest req = new() { Id = Id };
            return Ok(await _context.Send(req));
        }


        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(CreateRestaurantCommandRequest restaurant)
        {
            await _context.Send(restaurant);

            return Ok();
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(DeleteRestaurantCommandRequest id)
        {
            await _context.Send(id);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRestaurantss(DeleteProductFromRestaurantRequest id)
        {
            await _context.Send(id);

            return NoContent();
        }



    }
}
