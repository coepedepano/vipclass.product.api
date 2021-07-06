﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vipclass.products.Domain.Models;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Controllers
{
    [Route("v1/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoriesRepository categoriesRepository)
        {
            _logger = logger;
            _categoriesRepository = categoriesRepository;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _categoriesRepository.GetAll();

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
        public async Task<IActionResult> Add([FromBody] Categories parameters)
        {
            try
            {
                var result = await _categoriesRepository.Add(parameters);

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
