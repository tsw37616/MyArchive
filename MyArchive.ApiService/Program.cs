using MyArchive.ApiService.Endpoints;
using MyArchive.ApiService.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//add ImageService 
builder.Services.AddSingleton<ImageService>(new ImageService(Path.Combine(Directory.GetCurrentDirectory(),"images")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.MapDefaultEndpoints();

app.MapImageEndpoints();

app.Run();

