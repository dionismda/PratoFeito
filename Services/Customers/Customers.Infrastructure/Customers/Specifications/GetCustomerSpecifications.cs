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

public class GetCustomerByNameSpecification : Specification<Customer>
{
    public GetCustomerByNameSpecification(PersonName name)
        : base(customer => customer.Name.FirstName == name.FirstName && customer.Name.LastName == name.LastName)
    {
    }

    public GetCustomerByNameSpecification(PersonName name, Identifier Id)
        : base(customer => customer.Name.FirstName == name.FirstName
            && customer.Name.LastName == name.LastName && customer.Id != Id)
    {
    }
}