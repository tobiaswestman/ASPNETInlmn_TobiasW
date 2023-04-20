using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }

    public IActionResult Details()
    {
        return View();
    }
}