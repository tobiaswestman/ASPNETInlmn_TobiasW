using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserService _accountService;
		private readonly JwtTokenValidation _jwtValidation;

		public AccountController(UserService accountService, JwtTokenValidation jwtValidation)
		{
			_accountService = accountService;
			_jwtValidation = jwtValidation;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountService.RegisterAsync(model);

				if (result.IsSuccessStatusCode)
					return RedirectToAction("Login", "Account");

				ModelState.AddModelError("", "Email or password is incorrect");
			}

			return View(model);
		}

		public IActionResult Login()
		{
			var token = HttpContext.Request.Cookies["accessToken"];

			if (_jwtValidation.ValidateToken(token!))
			{
				return RedirectToAction("Logout", "Account");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountService.LoginAsync(model);

				if (result.IsSuccessStatusCode)
				{
					var token = await result.Content.ReadAsStringAsync();
					HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
					{
						HttpOnly = true,
						Secure = true,
						Expires = DateTime.Now.AddHours(1)
					});

					return RedirectToAction("Index", "Admin");
				}

				ModelState.AddModelError("", "Email or password is incorrect");
			}
			return View(model);
		}

		public IActionResult Logout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Logout(string tokenName)
		{
			Response.Cookies.Delete(tokenName);

			return RedirectToAction("Index", "Home");
		}

		public IActionResult UnauthorizedAcc()
		{
			return View();
		}
	}
}
