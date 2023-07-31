namespace Restaurants.Domain.Restaurants.Aggregates.MenuItems.Entities;

public sealed class MenuItem : Entity, IValidation
{
    public string Name { get; private set; }
    public Money Price { get; private set; }

    public MenuItem(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    public void Validate()
    {
        MenuItemValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
