namespace Restaurants.Infrastructure._Commons.Persistences;

public sealed class RestaurantContext : BaseDbContext
{
    public RestaurantContext(
        DbContextOptions<RestaurantContext> options,
        IConfiguration configuration,
        IServiceProvider services) : base(options, configuration, services)
    {
        Schema = nameof(ContextEnum.Restaurants).ToLower();
    }

    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    //public DbSet<MenuItem> MenuItems { get; set; } = null!;
    //public DbSet<RestaurantMenu> RestaurantMenus { get; set; } = null!;
    //public DbSet<RestaurantOrder> RestaurantOrders { get; set; } = null!;
    //public DbSet<RestaurantOrderItem> RestaurantOrderItem { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var interceptor = Services.GetRequiredService<EventsInterceptor<IRestaurantIntegrationEventMapper>>();

        optionsBuilder
            .AddInterceptors(interceptor);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RestaurantTypeMap());
    }
}
