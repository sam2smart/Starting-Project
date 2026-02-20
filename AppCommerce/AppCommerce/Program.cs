using AppCommerce.Components;
using Microsoft.EntityFrameworkCore;
using AppCommerce.Infrastructure.Data;
using AppCommerce.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// ------------ sam

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if(!db.Products.Any())
    {
        db.Products.AddRange(
            new Product

            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Description = "Gaming Laptop",
                Price = 1200,
                StockQuantity = 10
            },
            new Product

            {
                Id = Guid.NewGuid(),
                Name = "Phone",
                Description = "Smart Phone",
                Price = 800,
                StockQuantity = 20
            }
            );

        db.SaveChanges();
    }
}

    //------------- sam

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


