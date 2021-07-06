using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vipclass.products.Domain.Models;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Controllers
{
    [Route("v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _productsRepository.Get(id);

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
                var data = await _productsRepository.GetAll();

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
        public async Task<IActionResult> Add([FromBody] Products parameters)
        {
            try
            {
                var result = await _productsRepository.Add(parameters);

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
        public async Task<IActionResult> Update([FromBody] Products entity)
        {
            try
            {
                var result = await _productsRepository.Update(entity);

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
                var result = await _productsRepository.Delete(id);

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
