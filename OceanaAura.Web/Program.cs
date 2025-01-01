using Microsoft.Extensions.Configuration;
using OceanaAura.Application;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Models.Email;
using OceanaAura.Identity;
using OceanaAura.Infrastructure;
using OceanaAura.Persistence;
using OceanaAura.Web.Extensions;
using OceanaAura.Web.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); // Adds Razor Pages support, necessary for rendering views
builder.Services.AddControllersWithViews(); // Ensures MVC and ViewEngine are available

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors();
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<CalculateOrder>();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add Session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout as needed
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP only (more secure)
    options.Cookie.IsEssential = true; // Mark the session cookie as essential for the app
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

// Ensure session middleware is placed here, before routing
app.UseSession(); // Enable session

app.UseRouting();

app.UseCors("all");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
