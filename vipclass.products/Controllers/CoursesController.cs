using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vipclass.products.Domain.Models;
using vipclass.products.Domain.Models.Signature;
using vipclass.products.Repository.Interface;
//using vipclass.products.Services.Interface;

namespace vipclass.products.Controllers
{
    [Route("v1/course")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly ICoursesRepository _coursesRepository;
        //private readonly ICourseServices _courseServices;

        public CoursesController(ILogger<CoursesController> logger, ICoursesRepository courseRepository)
        {
            _logger = logger;
            _coursesRepository = courseRepository;
            //_courseServices = courseServices;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _coursesRepository.Get(id);

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
                var data = await _coursesRepository.GetAll();

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
        public async Task<IActionResult> Add([FromBody] AddCourseSignature parameters)
        {
            try
            {
                await _coursesRepository.Save(parameters);

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
        public async Task<IActionResult> Update([FromBody] Courses entity)
        {
            try
            {
                var result = await _coursesRepository.Update(entity);

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
                var result = await _coursesRepository.Delete(id);

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
