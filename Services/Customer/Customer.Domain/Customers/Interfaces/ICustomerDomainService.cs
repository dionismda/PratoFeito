namespace Customer.Domain.Customers.Interfaces;
public interface ICustomerDomainService : IDomainService<CustomerEntity, CustomerQueryModel>
{
    Task<CustomerOrderEntity> InsertAsync(CustomerOrderEntity entity, CancellationToken cancellation, bool autoCommit = true);
    Task<CustomerOrderEntity?> GetCustomerOrderByIdAsync(Guid id, CancellationToken cancellation);
    Task<CustomerOrderEntity> UpdateAsync(CustomerOrderEntity entity, CancellationToken cancellation, bool autoCommit = true);
}
