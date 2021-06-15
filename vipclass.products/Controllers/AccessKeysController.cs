using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vipclass.products.Data;
using vipclass.products.Models;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("v1/accesskeys")]
    public class AccessKeysController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<AccessKeys>>> Get([FromServices] DataContext context)
        {
            var accessKeys = await context.AccessKeys.ToListAsync();
            return accessKeys;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<AccessKeys>> Post(
            [FromServices] DataContext context,
            [FromBody] AccessKeys model)
        {
            if (ModelState.IsValid)
            {
                context.AccessKeys.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
