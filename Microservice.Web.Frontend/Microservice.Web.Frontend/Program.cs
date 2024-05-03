using Microservice.Web.Frontend.Servcies.BasketService;
using Microservice.Web.Frontend.Servcies.ProductServices;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductService>(x =>
{
	return new ProductService(new RestClient(builder.Configuration["MicroServiceAddress:Product:url"]));
});

builder.Services.AddScoped<IBasketService>(x =>
{
    return new BasketService(new RestClient(builder.Configuration["MicroServiceAddress:BasketService:url"]));
});

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
