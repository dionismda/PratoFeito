namespace Customers.Domain.Customers.Specifications;

public static class CustomerSpecifications
{
    public static Expression<Func<Customer, bool>> CheckCustomerDuplicate(Customer entity)
    {
        return x => x.Name.FirstName == entity.Name.FirstName &&
                    x.Name.LastName == entity.Name.LastName;
    }

    public static Expression<Func<Customer, bool>> CheckCustomerDuplicateExceptById(Customer entity)
    {
        return x => (x.Name.FirstName == entity.Name.FirstName &&
                    x.Name.LastName == entity.Name.LastName) && (x.Id != entity.Id);
    }
}