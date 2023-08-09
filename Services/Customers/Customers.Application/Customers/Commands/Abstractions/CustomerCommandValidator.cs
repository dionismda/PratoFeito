namespace Customers.Application.Customers.Commands.Abstractions;

public abstract class CustomerCommandValidator<TCommand> : AbstractValidator<TCommand>
    where TCommand : CustomerCommand
{
    protected CustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .SetValidator(new PersonNameValidator());

        RuleFor(x => x.OrderLimit)
            .SetValidator(new MoneyValidator());
    }
}