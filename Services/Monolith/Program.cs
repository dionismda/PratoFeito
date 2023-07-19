var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<ExceptionHandlerMiddleware>();

builder.Services.CustomAddSwaggerService(builder.Configuration);

builder.Services.InjectionCustomerApi(builder.Configuration);

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

builder.Services.AddMvc()
        .ConfigureApiBehaviorOptions(opt =>
        {
            opt.SuppressInferBindingSourcesForParameters = true;
        })
        .AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.CustomConfigureSwagger(builder.Configuration);
}

app.UseCors(opt =>
{
    opt.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
