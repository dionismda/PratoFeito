namespace Customers.Domain.Customers.Services;

public sealed class CustomerDomainService : DomainService<Customer>, ICustomerDomainService
{
    private readonly INotificationDomainService _notificationDomainService;
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomainService(INotificationDomainService notificationDomainService, ICustomerRepository repository) : base(repository)
    {
        _notificationDomainService = notificationDomainService;
        _customerRepository = repository;
    }

    public override async Task InsertAsync(Customer entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await _customerRepository.GetAllAsync(new GetCustomerDuplicate(entity), cancellationToken), entity);

        await base.InsertAsync(entity, cancellationToken);
    }

    public override async Task UpdateAsync(Customer entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await _customerRepository.GetAllAsync(new GetCustomerDuplicateExceptId(entity), cancellationToken), entity);

        var customer = await _customerRepository.GetCustomerByIdAsync(entity.Id, cancellationToken);

        if (customer is null)
            throw new NotFoundException($"Customer not found {entity.Id}");

        if (!entity.Name.Equals(customer.Name))
            customer.ChangeName(entity.Name);

        if (!entity.OrderLimit.Equals(customer.OrderLimit))
            customer.ChangeOrderLimit(entity.OrderLimit);

        customer.Validate();

        _customerRepository.Update(customer);

        await _customerRepository.CommitAsync(cancellationToken);
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
