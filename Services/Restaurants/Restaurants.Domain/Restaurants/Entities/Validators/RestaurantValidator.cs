namespace Restaurants.Domain.Restaurants.Entities.Validators;

public sealed class RestaurantValidator : AbstractValidator<Restaurant>
{
    public RestaurantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(1);

        RuleFor(x => x.Menu)
            .SetValidator(new RestaurantMenuValidator());

        RuleFor(x => x.State)
            .IsInEnum();
    }
}
