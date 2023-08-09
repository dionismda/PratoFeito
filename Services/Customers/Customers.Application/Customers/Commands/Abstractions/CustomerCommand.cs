namespace Customers.Application.Customers.Commands.Abstractions;

public abstract class CustomerCommand : ICommand<Customer>
{
    public PersonName Name { get; private set; } = null!;
    public Money OrderLimit { get; private set; } = null!;

    protected CustomerCommand() { }

    protected CustomerCommand(PersonName name, Money orderLimit) : this()
    {
        Name = name;
        OrderLimit = orderLimit;
    }
}