using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vipclass.products.Data;
using vipclass.products.Models;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("v1/unlimitedauctions")]
    public class UnlimitedAuctionsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<UnlimitedAuctions>>> Get([FromServices] DataContext context)
        {
            var unlimitedAuctions = await context.UnlimitedAuctions.ToListAsync();
            return unlimitedAuctions;
        }
    }
}
