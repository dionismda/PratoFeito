namespace Customer.Domain.Customers.Commands.Handlers;

public class CustomerHandlers : ICommandHandler<CreateCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(CreateCustomerCommand command, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
