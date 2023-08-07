namespace Customers.Domain.Customers.Extensions;

public static class CustomerLinqExtension
{
    public static bool HasName(this IEnumerable<Customer> customers, PersonName name)
    {
        return customers.Any(x => x.Name.Equals(name));
    }
}
