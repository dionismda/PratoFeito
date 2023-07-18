namespace Customers.Domain.Customers.Specifications;

public class GetCustomerAllSpecification : Specification<Customer>
{
    public GetCustomerAllSpecification() : base(null) { }
}

public class GetCustomerByIdSpecification : Specification<Customer>
{
    public GetCustomerByIdSpecification(Identifier Id) : base(customer => customer.Id.Id == Id.Id)
    {
    }
}

public class GetCustomerDuplicate : Specification<Customer>
{
    public GetCustomerDuplicate(Customer customer) : base(CustomerCriteria.CheckCustomerDuplicate(customer))
    {
    }
}

public class GetCustomerDuplicateExceptId : Specification<Customer>
{
    public GetCustomerDuplicateExceptId(Customer customer) : base(CustomerCriteria.CheckCustomerDuplicateExceptId(customer))
    {
    }
}