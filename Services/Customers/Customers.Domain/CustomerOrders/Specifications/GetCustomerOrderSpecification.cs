namespace Customers.Domain.CustomerOrders.Specifications;

public class GetCustomerOrderAllSpecification : Specification<CustomerOrder>
{
    public GetCustomerOrderAllSpecification() : base(null)
    {
    }
}

public class GetCustomerOrderByIdSpecification : Specification<CustomerOrder>
{
    public GetCustomerOrderByIdSpecification(Identifier Id) : base(customerOrder => customerOrder.Id.Id == Id.Id)
    {
    }
}