using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ILogger<SensorController> _logger;
        private readonly ISensorRepository _sensorRepository;

        public SensorController(ILogger<SensorController> logger, ISensorRepository sensorRepository)
        {
            _logger = logger;
            _sensorRepository = sensorRepository;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            try
            {
                var data = _sensorRepository.ListAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to get data");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromBody]long step)
        {
            try
            {
                var result = _sensorRepository.Insert(step);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to set data");
                return new StatusCodeResult(500);
            }
        }
    }
}
