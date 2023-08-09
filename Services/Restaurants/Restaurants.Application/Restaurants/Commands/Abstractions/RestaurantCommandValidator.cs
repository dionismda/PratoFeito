namespace Restaurants.Application.Restaurants.Commands.Abstractions;

public abstract class RestaurantCommandValidator<TCommand> : AbstractValidator<TCommand>
    where TCommand : RestaurantCommand
{
    protected RestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);
    }
}