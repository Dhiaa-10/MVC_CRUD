using M8E1.Store;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ProductStore>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Products}/{action=Index}/{id?}"
);

app.Run();
