using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Features.CQRS.Product.Command.CreateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Product.Command.DeleteCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Product.Command.UpdateCommand;
using RestaurantDashboardApi.Application.Features.CQRS.Product.Queries;
using RestaurantDashboardApi.Domain.Entities;
using RestaurantDashboardApi.Persistence.AppDbContext;

namespace RestaurantDashboardApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _context;

        public ProductsController(IMediator context)
        {
            _context = context;
        }

        // GET: api/Products
        [Authorize(Roles ="RestaurantCase, Waiter")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(GetAllProductCommandRequest req)
        {

            return Ok(await _context.Send(req));
        }

 

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(UpdateProductCommandRequest product)
        {
            await _context.Send(product);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductCommandRequest product)
        {
            await _context.Send(product);
            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest id)
        {
            await _context.Send(id);

            return NoContent();
        }


    }
}
