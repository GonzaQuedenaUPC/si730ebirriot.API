using Microsoft.EntityFrameworkCore;
using si730ebirriot.API.Inventory.Application.Internal.CommandServices;
using si730ebirriot.API.Inventory.Application.Internal.QueryServices;
using si730ebirriot.API.Inventory.Domain.Repositories;
using si730ebirriot.API.Inventory.Domain.Services;
using si730ebirriot.API.Inventory.Infrastructure.Persistence.EFC.Repositories;
using si730ebirriot.API.Shared.Domain.Repositories;
using si730ebirriot.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using si730ebirriot.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebirriot.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null)
{
    throw new InvalidOperationException("Connection string not found.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {

        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Inventory Bounded Context
builder.Services.AddScoped<IThingRepository, ThingRepository>();
builder.Services.AddScoped<IThingQueryService, ThingQueryService>();
builder.Services.AddScoped<IThingCommandService, ThingCommandService>();

/*// OrderItem Bounded Context
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemQueryService, OrderItemQueryService>();
builder.Services.AddScoped<IOrderItemCommandService, OrderItemCommandService>();*/

/*builder.Services.AddScoped<IInventoryItemContextFacade, InventoryItemContextFacade>();*/

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

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