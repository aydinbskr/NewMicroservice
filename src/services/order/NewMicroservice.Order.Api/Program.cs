using Microsoft.EntityFrameworkCore;
using NewMicroservice.Order.Api.Endpoints;
using NewMicroservice.Order.Application;
using NewMicroservice.Order.Application.Contracts.Repositories;
using NewMicroservice.Order.Application.Contracts.UnitOfWork;
using NewMicroservice.Order.Persistence;
using NewMicroservice.Order.Persistence.Repositories;
using NewMicroservice.Order.Persistence.UnitOfWork;
using NewMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCommonServiceExt(typeof(OrderApplicationAssembly));
builder.Services.AddDbContext<AppDbContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")); });
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddVersioningExt();
var app = builder.Build();

app.AddOrderGroupEndpointExt(app.AddVersionSetExt());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

