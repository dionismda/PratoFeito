namespace Authentication;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {

        services
            .AddCors()
            .AddOptions()
            .AddHttpContextAccessor();

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

        services.InjectAuthentication(Configuration);

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