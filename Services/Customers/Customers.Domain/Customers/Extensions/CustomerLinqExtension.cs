namespace Customers.Domain.Customers.Extensions;

public static class CustomerLinqExtension
{
    public static bool HasName(this IEnumerable<Customer> modulo, PersonName name)
    {
        return modulo.Any(x => x.Name.Equals(name));
    }
}
