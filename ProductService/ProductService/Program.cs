using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Contexts;
using ProductService.Model.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Connection string
builder.Services.AddDbContext<ProductDatabaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductService")));
#endregion
builder.Services.AddTransient<IProductService, ProductServices>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

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
