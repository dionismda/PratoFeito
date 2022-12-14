namespace Customer.Insfrastructure.Repositories;

public sealed class CustomerRepositoty : BaseRepository<CustomerEntity, CustomerQueryModel>, ICustomerRepository
{
    public CustomerRepositoty(CustomerDbContext context,
                              IConnectionDapperManager connectionDapper) : base(context, connectionDapper)
    {
    }

    protected override string GetBaseSql()
    {
        throw new NotImplementedException();
    }

    protected override string GetFilter(IBaseParamModel? paramModel)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerOrderEntity?> GetCustomerOrderByIdAsync(Guid id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerOrderEntity> InsertAsync(CustomerOrderEntity entity, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerOrderEntity> UpdateAsync(CustomerOrderEntity entity, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
