using Microsoft.AspNetCore.Mvc;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "O Zago é gay";
        }

        [HttpPost]
        public string Add()
        {
            return "O Zago é gay";
        }

        [HttpPut]
        public string Incluir()
        {
            return "O Zago é gay";
        }

        [HttpDelete]
        public string Delete()
        {
            return "O Zago é gay";
        }
    }
}
