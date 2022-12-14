namespace Customer.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services
            .AddCors()
            .AddOptions()
            .AddHttpContextAccessor()
            .CustomAddAuthentication(Configuration)
            .CustomAddSwaggerService(Configuration)
            .CustomAddVersioningService();

        services.AddMvc()
            .ConfigureApiBehaviorOptions(opt =>
            {
                opt.SuppressInferBindingSourcesForParameters = true;
                opt.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddEndpointsApiExplorer();

        services.InjectCustomerApi(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.CustomConfigureSwagger(Configuration);

        app.UseRouting();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}