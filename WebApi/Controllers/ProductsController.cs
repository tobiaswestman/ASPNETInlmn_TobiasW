using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApi.Filters;
using WebApi.Models.DTO;
using WebApi.Services;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [Route("Tag")]
        [HttpGet]
        public async Task<IActionResult> GetByTag(string tag)
        {
            return Ok(await _productService.GetByTagAsync(tag));
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }

        [Authorize(Roles = "Admin, ProductManager")]
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO dto)
        {
            if (await _productService.CreateAsync(dto))
                return Created("", null);

            return BadRequest();
        }

        [Authorize(Roles = "Admin, ProductManager")]
        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productService.DeleteAsync(id))
                return Ok();

            return BadRequest();
        }
    }
}
