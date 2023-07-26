namespace Customers.Domain.Customers.Criterias;

public static class CustomerCriteria
{
    public static Expression<Func<Customer, bool>> CheckCustomerDuplicate(Customer entity)
    {
        return x => x.Name.FirstName == entity.Name.FirstName &&
                    x.Name.LastName == entity.Name.LastName && x.Id != entity.Id;
    }
}