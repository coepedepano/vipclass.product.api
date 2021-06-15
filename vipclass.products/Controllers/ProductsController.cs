using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vipclass.products.Data;
using vipclass.products.Models;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<Products>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Products>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products
            .Include(x => x.TypeProduts)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<Products>> GetByTypeProduct([FromServices] DataContext context, int id)
        {
            var product = await context.Products
            .Include(x => x.TypeProduts)
            .AsNoTracking()
            .Where(x => x.TypeProduts.Id == id)
            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
    }
}
