using WSS.VulnShop.Domain.Products.GetAllProducts;
using WSS.VulnShop.Domain.Repository;
using WSS.VulnShop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetProductsCommandHandler>());
builder.Services.AddScoped<IProductsRepository, ProductsRepository>(sp => new ProductsRepository(builder.Configuration));
builder.Services.AddScoped<ICartRepository, CartRepository>(sp => new CartRepository(builder.Configuration));
builder.Services.AddScoped<IWishListRepository, WishListRepository>(sp => new WishListRepository(builder.Configuration));

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
      options.ApiName = "myApi";
      options.Authority = "https://localhost:44305";
    });
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
  builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
