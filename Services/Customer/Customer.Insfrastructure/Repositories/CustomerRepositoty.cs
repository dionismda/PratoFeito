namespace Customer.Insfrastructure.Repositories;

public sealed class CustomerRepositoty : BaseRepository<CustomerEntity, CustomerQueryModel>, ICustomerRepository
{
    public CustomerRepositoty(CustomerDbContext context,
                              IConnectionDapperManager connectionDapper) : base(context, connectionDapper)
    {
    }

    protected override string GetBaseSql()
    {
        return $"select * from customer where tenant_id = '{Context.TenantId}'";
    }

    protected override string GetFilter(IBaseParamModel? paramModel)
    {
        if (paramModel == null)
            return "";

        var filter = "";

        return filter;
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
