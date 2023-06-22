using LordSolutions.Data;
using LordSolutions.Data.Context;
using LordSolutions.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<LordSolutionsDbContext>();
builder.Services.AddScoped<ILordSolutionsDbContext, LordSolutionsDbContext>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IFacturaServices, FacturaServices>();
builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IProveedorServices, ProveedorServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
