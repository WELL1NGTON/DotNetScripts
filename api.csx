#r "sdk:Microsoft.NET.Sdk.Web"

#r "nuget:Swashbuckle.AspNetCore,6.2.3"

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var args = Environment.GetCommandLineArgs();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/hello-world", () => "Hello world")
    .WithName("HelloWorld");

app.MapGet("/", () => "Script running from a CSX file!")
    .WithName("Index");

app.Run();
