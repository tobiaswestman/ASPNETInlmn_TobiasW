using WebApp.Models.dtos;

namespace WebApp.Services;

public class UserService
{
	private readonly IConfiguration _config;

	public UserService(IConfiguration config)
	{
		_config = config;
	}

	public async Task<HttpResponseMessage> RegisterAsync(RegisterDTO dto)
	{
		using var http = new HttpClient();
		return await http.PostAsJsonAsync($"https://localhost:7024/api/Authentication/Register?key={_config.GetValue<string>("ApiKey")}", dto);
	}

	public async Task<HttpResponseMessage> LoginAsync(LoginDTO dto)
	{
		using var http = new HttpClient();
		return await http.PostAsJsonAsync($"https://localhost:7024/api/Authentication/Login?key={_config.GetValue<string>("ApiKey")}", dto);
	}
}
