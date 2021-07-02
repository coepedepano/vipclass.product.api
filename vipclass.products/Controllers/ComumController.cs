using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using vipclass.products.Domain.Models;

namespace vipclass.products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComumController : ControllerBase
    {
        [HttpGet]
        [Route(nameof(ListAllCategorie))]
        public IEnumerable<Categorie> ListAllCategorie()
        {
            var categorie = new Categorie();
            return  categorie.ListAll();
        }

        [HttpGet]
        [Route(nameof(ListAllCoin))]
        public IEnumerable<Coin> ListAllCoin()
        {
            var coin = new Coin();
            return coin.ListAll();
        }
    }
}
