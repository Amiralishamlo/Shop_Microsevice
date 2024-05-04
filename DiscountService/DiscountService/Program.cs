using DiscountService.GRPC;
using DiscountService.Infrastructure.Contexts;
using DiscountService.Infrastructure.Mapping;
using DiscountService.Model.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Connection string
builder.Services.AddDbContext<DiscountDataBaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DiscountService")));
#endregion
builder.Services.AddAutoMapper(typeof(DiscountMappingProfile));
builder.Services.AddTransient<IDiscountService, DiscountService.Model.Services.DiscountService>();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapGrpcService<GRPCDiscountService>();
app.MapControllers();


app.Run();
