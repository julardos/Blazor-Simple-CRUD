using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TrustBoxes.Data;
using TrustBoxes.Models;

var builder = WebApplication.CreateBuilder(args);

mySQLSqlHelper.conStr = builder.Configuration["ConnectionStrings:Default"];

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<MasterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
