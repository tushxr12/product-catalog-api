using HPlusSport.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ShopContext>(options => {
    options.UseInMemoryDatabase("Shop");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<ShopContext>();
//     await db.Database.EnsureCreatedAsync();
// }

// // For minimal APIs
// app.MapGet("/products", async (ShopContext context) =>
// {
//     return await context.Products.ToArrayAsync();
// });

// app.MapGet("/products/{id}", async (int id, ShopContext context) =>
// {
//     var product = await context.Products.FindAsync(id);
//     return product is not null ? Results.Ok(product) : Results.NotFound();
// });

// app.MapGet("/products/available", async (ShopContext context) =>
// {
//     var products = await context.Products.Where(x => x.IsAvailable).ToArrayAsync();
//     return Results.Ok(products);
// });

app.Run();