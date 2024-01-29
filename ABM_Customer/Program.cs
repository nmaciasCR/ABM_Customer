using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ABM_Customer.Business.Interfaces.ICustomer, ABM_Customer.Business.Customer>();
builder.Services.AddSingleton<ABM_Customer.Services.ICRM_Customer, ABM_Customer.Services.CRM_Customer>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Base de datos
builder.Services.AddDbContext<ABM_Customer.Data.Entities.CopernicusContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Copernicus"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
