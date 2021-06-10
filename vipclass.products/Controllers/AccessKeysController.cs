using Microsoft.AspNetCore.Mvc;

namespace vipclass.products.Controllers
{
    [ApiController]
    [Route("accesskeys")]
    public class AccessKeysController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public string Get()
        {
            return "O Zago é gay";
        }

        [HttpPost]
        [Route("add")]
        public string Add()
        {
            return "O Zago é gay";
        }

        [HttpPut]
        [Route("put")]
        public string Incluir()
        {
            return "O Zago é gay";
        }

        [HttpDelete]
        [Route("delete")]
        public string Delete()
        {
            return "O Zago é gay";
        }
    }
}
