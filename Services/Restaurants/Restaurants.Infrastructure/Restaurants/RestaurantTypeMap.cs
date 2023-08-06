namespace Restaurants.Infrastructure.Restaurants;

public class RestaurantTypeMap : AggregateTypeMap<Restaurant>
{
    public override void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.State)
            .IsRequired()
            .HasColumnName("state");
    }
}
