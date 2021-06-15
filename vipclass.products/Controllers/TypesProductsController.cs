using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vipclass.products.Data;
using vipclass.products.Models;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("v1/typesproducts")]
    public class TypesProductsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<TypeProduts>>> Get([FromServices] DataContext context)
        {
            var typesProducts = await context.TypeProduts.ToListAsync();
            return typesProducts;
        }
    }
}
