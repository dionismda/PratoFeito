namespace Customers.Application.Customers.Commands.Abstractions;

public abstract class CustomerCommandValidator<TCommand> : AbstractValidator<TCommand>
    where TCommand : CustomerCommand
{
    protected CustomerCommandValidator(ICustomerRepository customerRepository)
    {
        RuleFor(x => x.Name)
            .SetValidator(new PersonNameValidator())
            .MustAsync(async (personName, cancellationToken) =>
            {
                return !await customerRepository.IsNameUniqueAsync(personName, cancellationToken);

            }).WithMessage("Name already exists");

        RuleFor(x => x.OrderLimit)
            .SetValidator(new MoneyValidator());
    }
}