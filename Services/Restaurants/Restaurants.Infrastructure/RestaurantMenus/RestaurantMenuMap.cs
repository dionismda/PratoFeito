using Restaurants.Domain.RestaurantMenus.Entities;

namespace Restaurants.Infrastructure.RestaurantMenus;

public sealed class RestaurantMenuMap : EntityTypeMap<RestaurantMenu>
{
    public override void Configure(EntityTypeBuilder<RestaurantMenu> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.MenuVersion)
            .HasColumnName("menu_version")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasMany(x => x.MenuItems)
            .WithOne()
            .HasForeignKey("fk_restaurant_menu");
    }
}
