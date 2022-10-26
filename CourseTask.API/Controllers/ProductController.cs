using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace CourseTask.API.Controllers
{
    [Authorize]
    [Route("api/products")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetProducts([FromQuery] PagingParameters pagingParameters)
        {
            var products = _productService.GetAllProducts(pagingParameters);

            if (products == null)
            {
                _logger.LogInformation("No Products found");
                return NotFound();
            }
            _logger.LogInformation("Received Products");
            return Ok(products);
        }
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int Id)
        {
            var product = _productService.GetProductById(Id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [HttpGet("[action]")]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
            var product = _productService.GetAllProductsByCategory(categoryId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductsForCreationsDto productDto)
        {
            var productToReturn = _productService.CreateProduct(productDto);
            return CreatedAtRoute("GetProduct", new { id = productToReturn.ProductId }, productToReturn.customReturn);

        }
        [HttpPut]
        public IActionResult UpdateProduct(ProductsForUpdateDto productDto)
        {
            var productToReturn = _productService.UpdateProduct(productDto);
            return CreatedAtRoute("GetProduct", new { id = productToReturn.ProductId }, productToReturn.customReturn);

        }
        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var productToReturn = _productService.DeleteProduct(productId);
            return Ok(productToReturn);
        }

        [HttpPatch("{productId}")]
        public IActionResult UpdatePatchProduct(int productId, JsonPatchDocument<ProductsForUpdateDto> productsPatch)
        {
            var productToReturn = _productService.PartiallyUpdateProduct(productId, productsPatch);
            return Ok(productToReturn);
        }
    }
}