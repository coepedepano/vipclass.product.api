﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vipclass.products.Data;
using vipclass.products.Models;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("v1/fixedprice")]
    public class FixedPriceController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<List<FixedPrice>>> Get([FromServices] DataContext context)
        {
            var fixedPrice = await context.FixedPrice.ToListAsync();
            return fixedPrice;
        }
    }
}
