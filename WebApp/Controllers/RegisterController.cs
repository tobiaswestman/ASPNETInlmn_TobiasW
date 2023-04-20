using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class Register : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}