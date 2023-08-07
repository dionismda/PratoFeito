using Restaurants.Domain.RestaurantMenus.Aggregates.MenuItems.Entities;

namespace Restaurants.Infrastructure.RestaurantMenus.Aggregates.MenuItems;

public sealed class MenuItemMap : EntityTypeMap<MenuItem>
{
    public override void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(x => x.Price)
            .HasColumnName("price")
            .IsRequired()
            .MoneyConversion();
    }
}
