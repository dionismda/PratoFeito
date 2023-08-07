namespace Customers.Domain.Customers.Services;

public sealed class CustomerDomainService : DomainService<Customer>, ICustomerDomainService
{
    private readonly ICustomerNotificationDomainService _notificationDomainService;
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomainService(
        ICustomerNotificationDomainService notificationDomainService,
        ICustomerRepository customerRepository) : base(customerRepository)
    {
        _notificationDomainService = notificationDomainService;
        _customerRepository = customerRepository;
    }

    public override async Task InsertAsync(Customer entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await _customerRepository.GetCustomerDuplicateAsync(entity, cancellationToken), entity);

        await base.InsertAsync(entity, cancellationToken);
    }

    public override async Task UpdateAsync(Customer entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await _customerRepository.GetCustomerDuplicateAsync(entity, cancellationToken), entity);

        var customer = await _customerRepository.GetCustomerByIdAsync(entity.Id, cancellationToken)
            ?? throw new NotFoundException($"Customer not found {entity.Id}");

        if (!entity.Name.Equals(customer.Name))
            customer.ChangeName(entity.Name);

        if (!entity.OrderLimit.Equals(customer.OrderLimit))
            customer.ChangeOrderLimit(entity.OrderLimit);

        customer.Validate();

        await base.UpdateAsync(customer, cancellationToken);
    }

    public async Task ValidateFields(Func<Task<IList<Customer>>> getResultQueryValidate, Customer entity)
    {
        var dbEntity = await getResultQueryValidate();

        if (dbEntity.HasName(entity.Name))
        {
            _notificationDomainService.AddError(nameof(entity.Name), "Field already exists");
        }

        _notificationDomainService.Validate("Error to save entity");
    }
}
