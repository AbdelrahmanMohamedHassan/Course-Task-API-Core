using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace CourseTask.API.Controllers
{
    [Authorize]
    [Route("api/categories")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var courses = _categoryService.GetCategories();

            if (courses == null)
            {
                _logger.LogInformation("No Categories found");
                return NotFound();
            }
            _logger.LogInformation("Received Categories");
            return Ok(courses);
        }
    }
}