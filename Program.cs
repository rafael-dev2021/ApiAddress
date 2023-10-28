using ApiAddressSearchBackEnd.EndPoints;
using ApiAddressSearchBackEnd.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJsonSettings();
builder.Services.AddApiAddressDatabase(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hellos World!");
app.MapAddressServiceEndpoints();

app.UseHttpsRedirection();

app.Run();

