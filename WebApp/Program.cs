using WebApp.Services;
using WebApp.Helpers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<JwtTokenValidation>();
builder.Services.AddScoped<AdminServices>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
