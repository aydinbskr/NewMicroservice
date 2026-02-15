using NewMicroservice.Basket.Api;
using NewMicroservice.Basket.Api.Features;
using NewMicroservice.Basket.Api.Features.Baskets;
using NewMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCommonServiceExt(typeof(BasketAssembly));
//builder.Services.AddMasstransitExt(builder.Configuration);
builder.Services.AddScoped<BasketService>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddVersioningExt();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.AddBasketGroupEndpointExt(app.AddVersionSetExt());

app.Run();
