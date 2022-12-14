namespace Customer.Domain.Customers.Interfaces;

public interface ICustomerRepository : IRepository<CustomerEntity, CustomerQueryModel>
{
    Task<CustomerOrderEntity> InsertAsync(CustomerOrderEntity entity, CancellationToken cancellation);
    Task<CustomerOrderEntity?> GetCustomerOrderByIdAsync(Guid id, CancellationToken cancellation);
    Task<CustomerOrderEntity> UpdateAsync(CustomerOrderEntity entity, CancellationToken cancellation);
}
