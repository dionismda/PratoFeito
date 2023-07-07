namespace Customers.Application.Customers.Queries;

public sealed class CustomerQueires : ICustomerQueires
{
    private readonly CustomersContext _context;

    public CustomerQueires(CustomersContext context)
    {
        _context = context;
    }

    public async Task<GetCustomerOrdersByCustomerIdViewModel?> GetCustomerOrdersByCustomerIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await _context.Customers
                            .Where(c => c.Id.Id == id.Id)
                            .Join(
                                _context.CustomerOrders,
                                customer => customer.Id,
                                customerOrder => customerOrder.Id,
                                (customer, customerOrder) => new
                                {
                                    Customer = customer,
                                    CustomerOrder = customerOrder
                                })
                            .Select(x => new GetCustomerOrdersByCustomerIdViewModel()
                            {
                                Id = x.Customer.Id.Id,
                                Name = x.Customer.Name.ToString(),
                                Orders = new List<CustomerOrdersByCustomerIdViewModel>
                                {
                                    new CustomerOrdersByCustomerIdViewModel
                                    {
                                        OrderTotal = x.CustomerOrder.OrderTotal.Amount,
                                        State = x.CustomerOrder.State
                                    }
                                }
                            })
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
    }
}
