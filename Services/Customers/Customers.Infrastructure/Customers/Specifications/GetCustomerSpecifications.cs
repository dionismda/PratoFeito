namespace Customers.Infrastructure.Customers.Specifications;

public class GetCustomerAllSpecification : Specification<Customer>
{
    public GetCustomerAllSpecification() : base(null) { }
}

public class GetCustomerByIdSpecification : Specification<Customer>
{
    public GetCustomerByIdSpecification(Identifier Id) : base(customer => customer.Id == Id)
    {
    }
}

public class GetCustomerDuplicate : Specification<Customer>
{
    public GetCustomerDuplicate(Customer customer) : base(CustomerCriteria.CheckCustomerDuplicate(customer))
    {
    }
}