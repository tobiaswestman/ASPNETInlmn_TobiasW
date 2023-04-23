using WebApp.Models;

namespace WebApp.Services;

public class ProductService
{
    private readonly IConfiguration _config;

    public ProductService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        using var http = new HttpClient();
        var result = await http.GetFromJsonAsync<IEnumerable<ProductModel>>($"https://localhost:7024/api/Products/All?key={_config.GetValue<string>("ApiKey")}");
        return result!;
    }

    public async Task<ProductModel> GetProductAsync(int id)
    {
        using var http = new HttpClient();
        var result = await http.GetFromJsonAsync<ProductModel>($"https://localhost:7024/api/Products/Get?id={id}&key={_config.GetValue<string>("ApiKey")}");
        return result!;
    }

    public async Task<IEnumerable<ProductModel>> GetByTagAsync(string tag)
    {
        using var http = new HttpClient();
        var result = await http.GetFromJsonAsync<IEnumerable<ProductModel>>($"https://localhost:7024/api/Products/Tag?tag={tag}&key={_config.GetValue<string>("ApiKey")}");
        return result!;
    }

}
