using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vipclass.products.Data;
using vipclass.products.Models;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("v1/fileproducts")]
    public class FileProductsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<FileProducts>>> Get([FromServices] DataContext context)
        {
            var fileProducts = await context.FileProducts.ToListAsync();
            return fileProducts;
        }
    }
}
