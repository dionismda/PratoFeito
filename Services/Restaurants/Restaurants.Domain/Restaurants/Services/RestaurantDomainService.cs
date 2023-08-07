namespace Restaurants.Domain.Restaurants.Services;

public sealed class RestaurantDomainService : DomainService<Restaurant>, IRestaurantDomainService
{
    private readonly IRestaurantNotificationDomainService _notificationDomainService;
    private readonly IRestaurantRepository _restaurantRepository;
    public RestaurantDomainService(
        IRestaurantNotificationDomainService notificationDomainService,
        IRestaurantRepository restaurantRepository) : base(restaurantRepository)
    {
        _notificationDomainService = notificationDomainService;
        _restaurantRepository = restaurantRepository;
    }

    public override async Task InsertAsync(Restaurant entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await _restaurantRepository.GetRestaurantDuplicateAsync(entity, cancellationToken), entity);

        await base.InsertAsync(entity, cancellationToken);
    }

    public override async Task UpdateAsync(Restaurant entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await _restaurantRepository.GetRestaurantDuplicateAsync(entity, cancellationToken), entity);

        var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(entity.Id, cancellationToken)
            ?? throw new NotFoundException($"Restaurant not found {entity.Id}");

        restaurant.ChangeName(entity.Name);

        await base.UpdateAsync(restaurant, cancellationToken);
    }

    public async Task RestaurantOperationAsync(Restaurant entity, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(entity.Id, cancellationToken)
            ?? throw new NotFoundException($"Restaurant not found {entity.Id}");

        if (restaurant.State != entity.State)
        {
            switch (entity.State)
            {
                case RestaurantState.OPEN:
                    restaurant.CloseRestaurant();
                    break;
                case RestaurantState.CLOSED:
                case RestaurantState.CREATED:
                    restaurant.OpenRestaurant();
                    break;
            }
        }

        await base.UpdateAsync(restaurant, cancellationToken);
    }

    public async Task ValidateFields(Func<Task<IList<Restaurant>>> getResultQueryValidate, Restaurant entity)
    {
        var dbEntity = await getResultQueryValidate();

        if (dbEntity.HasName(entity.Name))
        {
            _notificationDomainService.AddError(nameof(entity.Name), "Field already exists");
        }

        _notificationDomainService.Validate("Error to save entity");
    }
}
