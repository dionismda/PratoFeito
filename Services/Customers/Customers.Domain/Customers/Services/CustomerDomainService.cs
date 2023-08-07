namespace Customers.Domain.Customers.Services;

public sealed class CustomerDomainService : DomainService<Customer>, ICustomerDomainService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomainService(ICustomerRepository customerRepository) : base(customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public override async Task UpdateAsync(Customer entity, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(entity.Id, cancellationToken)
            ?? throw new NotFoundException($"Customer not found {entity.Id}");

        if (!entity.Name.Equals(customer.Name))
            customer.ChangeName(entity.Name);

        if (!entity.OrderLimit.Equals(customer.OrderLimit))
            customer.ChangeOrderLimit(entity.OrderLimit);

        await base.UpdateAsync(customer, cancellationToken);
    }
}
