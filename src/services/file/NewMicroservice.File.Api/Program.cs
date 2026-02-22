using Microsoft.Extensions.FileProviders;
using NewMicroservice.File.Api;
using NewMicroservice.File.Api.Features.File;
using NewMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

builder.Services.AddCommonServiceExt(typeof(FileAssembly));
//builder.Services.AddMasstransitExt(builder.Configuration);
builder.Services.AddVersioningExt();


var app = builder.Build();

app.AddFileGroupEndpointExt(app.AddVersionSetExt());

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.Run();

