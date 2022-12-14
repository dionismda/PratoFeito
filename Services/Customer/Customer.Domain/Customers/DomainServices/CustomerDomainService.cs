namespace Customer.Domain.Customers.DomainServices;

public sealed class CustomerDomainService : BaseDomainService<CustomerEntity, CustomerQueryModel>, ICustomerDomainService
{
    private readonly ICustomerRepository _repository;

    public CustomerDomainService(ICustomerRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<CustomerOrderEntity?> GetCustomerOrderByIdAsync(Guid id, CancellationToken cancellation)
    {
        return await _repository.GetCustomerOrderByIdAsync(id, cancellation);
    }

    public async Task<CustomerOrderEntity> InsertAsync(CustomerOrderEntity entity, CancellationToken cancellation, bool autoCommit = true)
    {
        var result = await _repository.InsertAsync(entity, cancellation);

        if (autoCommit) await CommitAsync(cancellation);

        return result;
    }

    public async Task<CustomerOrderEntity> UpdateAsync(CustomerOrderEntity entity, CancellationToken cancellation, bool autoCommit = true)
    {
        var result = await _repository.UpdateAsync(entity, cancellation);

        if (autoCommit) await CommitAsync(cancellation);

        return result;
    }
}
