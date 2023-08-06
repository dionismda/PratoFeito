namespace Restaurants.Infrastructure.Restaurants.Aggregates.RestaurantMenus;

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
    }
}
