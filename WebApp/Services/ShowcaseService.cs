using WebApi.Models.DTO;

namespace WebApp.Services;

public class ShowcaseService
{
	private readonly IConfiguration _config;

	public ShowcaseService(IConfiguration config)
	{
		_config = config;
	}

	public async Task<ShowcaseDTO> GetLatestAsync()
	{
		using var http = new HttpClient();
		var result = await http.GetFromJsonAsync<ShowcaseDTO>($"https://localhost:7024/api/Showcase/Latest?key={_config.GetValue<string>("ApiKey")}");
		return result!;
	}
}
