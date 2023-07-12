namespace Customers.UnitTests.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommandBuilder : Builders<UpdateCustomerCommandBuilder, UpdateCustomerCommand>
{
    private Identifier Id { get; set; }
    private PersonName Name { get; set; }
    private Money OrderLimit { get; set; }

    public UpdateCustomerCommandBuilder()
    {
        Id = Identifier.CreateNew();
        Name = PersonNameBuilder.New().Build();
        OrderLimit = MoneyBuilder.New().Build();
    }

    public UpdateCustomerCommandBuilder ChangeId(Identifier id)
    {
        Id = id;
        return this;
    }

    public UpdateCustomerCommandBuilder ChangeName(PersonName name)
    {
        Name = name;
        return this;
    }

    public UpdateCustomerCommandBuilder ChangeOrderLimit(Money orderLimit)
    {
        OrderLimit = orderLimit;
        return this;
    }

    public override UpdateCustomerCommand Build()
    {
        return new UpdateCustomerCommand(Id, Name, OrderLimit);
    }
}
