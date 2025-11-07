using Microsoft.EntityFrameworkCore;
using EcommerceMVC.Data;
using EcommerceMVC.Repository;
using EcommerceMVC.Service;
using EcommerceMVC.Services;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.Mappers;
using EcommerceMVC.AppSetting;
using EcommerceMVC.JwtHelper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add db context  (added)
builder.Services.AddDbContext<MoviedbContext>(options => options.UseMySQL(
    builder.Configuration.GetConnectionString("DbConnection")));

// Add repository (added)

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService,  UserService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddHttpContextAccessor(); // For accessing HttpContext in services

builder.Services.AddAutoMapper(typeof(AutoMappers));

//added jwt
//add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["JwtSetting:Issuer"],
                ValidAudience = builder.Configuration["JwtSetting:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSetting:Key"]))
            };

            // Read token from cookie
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var token = context.Request.Cookies["AuthToken"];
                    if (!string.IsNullOrEmpty(token))
                        context.Token = token;

                    return Task.CompletedTask;
                }
            };
        });


//jwt end

builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JwtSetting"));

builder.Services.AddScoped<TokenGenerate>(); //added for jwt token generation


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller=Movie}/{action=GetMovies}/{id?}");


app.Run();
