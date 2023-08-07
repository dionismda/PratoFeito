namespace Restaurants.Domain.Restaurants.Entities.Validators;

public sealed class RestaurantValidator : AbstractValidator<Restaurant>
{
    public RestaurantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(1)
            .MaximumLength(255);

        RuleFor(x => x.State)
            .IsInEnum();
    }
}
