using Customers.Api;
using Microsoft.OpenApi.Models;
using Monolith.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var swaggerSettings = new SwaggerSettings();
    builder.Configuration.GetSection("Swagger").Bind(swaggerSettings);

    foreach (var msName in swaggerSettings.Microservices.Select(e => e.Name))
    {
        options.SwaggerDoc(msName, new OpenApiInfo
        {
            Title = swaggerSettings.Title,
            Version = msName,
            Description = swaggerSettings.Description
        });
    }

});

builder.Services.InjectionCustomerApi(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var swaggerSettings = new SwaggerSettings();
    builder.Configuration.GetSection("Swagger").Bind(swaggerSettings);

    app.UseSwagger(option => option.RouteTemplate = swaggerSettings.JsonRoute);

    app.UseSwaggerUI(option =>
    {
        foreach (var msName in swaggerSettings.Microservices.Select(e => e.Name))
        {
            option.SwaggerEndpoint($"/swagger/{msName}/swagger.json", $"{swaggerSettings.Title} {msName}");
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
