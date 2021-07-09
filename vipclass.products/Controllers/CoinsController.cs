using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vipclass.products.Domain.Models;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Controllers
{
    [Route("v1/coins")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private readonly ILogger<CoinsController> _logger;
        private readonly ICoinsRepository _coinsRepository;

        public CoinsController(ILogger<CoinsController> logger, ICoinsRepository coinsRepository)
        {
            _logger = logger;
            _coinsRepository = coinsRepository;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _coinsRepository.Get(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to get data");
                return new StatusCodeResult(500);
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _coinsRepository.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to get data");
                return new StatusCodeResult(500);
            }
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Coins entity)
        {
            try
            {
                var result = await _coinsRepository.Add(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to set data");
                return new StatusCodeResult(500);
            }
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Coins entity)
        {
            try
            {
                var result = await _coinsRepository.Update(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to set data");
                return new StatusCodeResult(500);
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                var result = await _coinsRepository.Delete(id);

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
