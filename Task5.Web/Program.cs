using System.Net;
using Task5.Application;
using Task5.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddNewtonsoftJson();

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

builder.WebHost.ConfigureKestrel(config =>
{
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
    {
        config.Listen(IPAddress.Any, Convert.ToInt32(
            Environment.GetEnvironmentVariable("PORT")));
    }
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserGenerator}/{action=Index}/{id?}");

app.Run();