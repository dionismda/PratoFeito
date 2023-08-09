namespace Restaurants.Application.Restaurants.Commands.CreateRestaurants;

public sealed class CreateRestaurantCommandValidator : RestaurantCommandValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator(IRestaurantRepository restaurantRepository) : base()
    {
        RuleFor(x => x.Name)
            .MustAsync(async (restaurantName, cancellationToken) =>
            {
                return !await restaurantRepository.IsRestaurantUnique(restaurantName, cancellationToken);

            }).WithMessage("Name already exists");
    }
}