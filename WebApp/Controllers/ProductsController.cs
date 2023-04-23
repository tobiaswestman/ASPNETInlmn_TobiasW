using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Details(int id)
    {
        return View(await _productService.GetProductAsync(id));
    }
}