using BasketService.Infrastructure.Contexts;
using BasketService.Infrastructure.Mapping;
using BasketService.Model.Services.BasketServices;
using BasketService.Model.Services.DiscountServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Connection string
builder.Services.AddDbContext<BasketDataBaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BasketService")));
#endregion
builder.Services.AddAutoMapper(typeof(BasketMappingProfile));

builder.Services.AddTransient<IBasketService, BasketService.Model.Services.BasketServices.BasketService>();
builder.Services.AddTransient<IDiscountService, BasketService.Model.Services.DiscountServices.DiscountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
