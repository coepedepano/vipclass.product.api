using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vipclass.products.Data;
using vipclass.products.Models;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("v1/timedauctions")]
    public class TimedAuctionsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<TimedAuctions>>> Get([FromServices] DataContext context)
        {
            var timeAuctions = await context.TimedAuctions.ToListAsync();
            return timeAuctions;
        }
    }
}
