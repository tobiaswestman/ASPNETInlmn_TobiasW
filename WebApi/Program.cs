using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Contexts;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => 
    x.UseSqlServer(builder.Configuration.GetConnectionString("DataConn")));
builder.Services.AddDbContext<IdentityContext>(x => 
    x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConn")));

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<CommentRepo>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ShowcaseRepo>();
builder.Services.AddScoped<JwtToken>();
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            if (string.IsNullOrEmpty(context?.Principal?.FindFirst("id")?.Value) || string.IsNullOrEmpty(context?.Principal?.Identity?.Name))
                context?.Fail("Unauthorized");

            return Task.CompletedTask;
        }
    };

    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration.GetSection("TokenValidation").GetValue<string>("ValidIssuer"),
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetSection("TokenValidation").GetValue<string>("ValidAudience"),
        ClockSkew = TimeSpan.FromSeconds(0),
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ProductManagerOnly", policy => policy.RequireRole("ProductManager"));
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();