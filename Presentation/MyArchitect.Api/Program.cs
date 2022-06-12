using Microsoft.EntityFrameworkCore;
using MyArchitect.Abstraction.Repositories;
using MyArchitect.Abstraction.Services;
using MyArchitect.Concrete.Mappings;
using MyArchitect.Concrete.Repositories;
using MyArchitect.Concrete.Services;
using MyArchitect.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Dependency Injection Servisleri

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OnionContext>(opt => opt.UseSqlServer(
    "Data Source=DESKTOP-5QUPQUE\\SQLEXPRESS;Initial Catalog=OnionArchitect;Integrated Security=true;"));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(CategoryMapper), typeof(ProductMapper));
#endregion 



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
