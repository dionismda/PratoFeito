namespace Customers.Domain.Customers.Services;

public sealed class CustomerDomainService : DomainService<Customer>, ICustomerDomainService
{
    private readonly INotificationDomainService _notificationDomainService;

    public CustomerDomainService(INotificationDomainService notificationDomainService, ICustomerRepository repository) : base(repository)
    {
        _notificationDomainService = notificationDomainService;
    }

    public async Task<IList<Customer>> GetCustomerAllAsync(CancellationToken cancellationToken)
    {
        return await Repository.GetAllAsync(new GetCustomerAllSpecification(), cancellationToken);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await Repository.GetByIdAsync(new GetCustomerByIdSpecification(id), cancellationToken);
    }

    public override async Task InsertAsync(Customer entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await Repository.GetAllAsync(new GetCustomerDuplicate(entity), cancellationToken), entity);

        await base.InsertAsync(entity, cancellationToken);
    }

    public override async Task UpdateAsync(Customer entity, CancellationToken cancellationToken)
    {
        await ValidateFields(async () => await Repository.GetAllAsync(new GetCustomerDuplicateExceptId(entity), cancellationToken), entity);

        var customer = await GetCustomerByIdAsync(entity.Id, cancellationToken);

        if (customer is null)
            throw new NotFoundException($"Customer not found {entity.Id}");

        if (!entity.Name.Equals(customer.Name))
            customer.ChangeName(entity.Name);

        if (!entity.OrderLimit.Equals(customer.OrderLimit))
            customer.ChangeOrderLimit(entity.OrderLimit);

        customer.Validate();

        Repository.Update(customer);

        await Repository.CommitAsync(cancellationToken);
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
