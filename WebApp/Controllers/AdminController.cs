using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Services;
using WebApp.ViewModels;
using System.Reflection;

namespace WebApp.Controllers;

public class AdminController : Controller
{

	private readonly JwtTokenValidation _jwtValidation;
	private readonly AdminServices _adminServices;

	public AdminController(JwtTokenValidation jwtValidation, AdminServices adminServices)
	{
		_jwtValidation = jwtValidation;
		_adminServices = adminServices;
	}

	public IActionResult Index()
	{
		string token = HttpContext.Request.Cookies["accessToken"]!;

		if (_jwtValidation.ValidateToken(token))
		{
			return View();
		}

		return RedirectToAction("UnauthorizedAcc", "Account");
	}

	public IActionResult AddProduct()
	{
		string token = HttpContext.Request.Cookies["accessToken"]!;

		if (_jwtValidation.ValidateToken(token))
		{
			return View();
		}

		return RedirectToAction("UnauthorizedAcc", "Account");
	}

	[HttpPost]
	public async Task<IActionResult> AddProduct(AddProductViewModel model)
	{
		string token = HttpContext.Request.Cookies["accessToken"]!;

		if (_jwtValidation.ValidateToken(token))
		{
			if(ModelState.IsValid)
			{
				var result = await _adminServices.AddProductAsync(model, token);
				if (result.IsSuccessStatusCode)
				{
					ModelState.Clear();
					model = new AddProductViewModel()
					{
						ConfirmationMessage = "The product has been added."
					};

					return View(model);
				}

				if(result.StatusCode == System.Net.HttpStatusCode.Forbidden)
					model.ConfirmationMessage = "You are not authorized for this action.";
				else
					model.ConfirmationMessage = "Something went wrong, try again.";
			}

			return View(model);
		}

		return RedirectToAction("UnauthorizedAcc", "Account");
	}

	public IActionResult DeleteProduct()
	{
		string token = HttpContext.Request.Cookies["accessToken"]!;

		if (_jwtValidation.ValidateToken(token))
		{
			return View();
		}

		return RedirectToAction("UnauthorizedAcc", "Account");
	}

	[HttpPost]
	public async Task<IActionResult> DeleteProduct(DeleteProductViewModel model)
	{
		string token = HttpContext.Request.Cookies["accessToken"]!;

		if (_jwtValidation.ValidateToken(token))
		{
			if (ModelState.IsValid)
			{
				var result = await _adminServices.DeleteProductAsync(model.Id, token);
				if (result.IsSuccessStatusCode)
				{
					ModelState.Clear();
					model = new DeleteProductViewModel()
					{
						ConfirmationMessage = "The product has been deleted."
					};

					return View(model);
				}

				if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
					model.ConfirmationMessage = "You are not authorized for this action.";
				else
					model.ConfirmationMessage = "Something went wrong, try again.";
			}

			return View(model);
		}

		return RedirectToAction("UnauthorizedAcc", "Account");
	}
}
