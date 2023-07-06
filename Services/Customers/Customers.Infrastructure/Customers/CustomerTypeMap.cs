namespace Customers.Infrastructure.Customers;

public sealed class CustomerTypeMap : AggregateTypeMap<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder
            .OwnsOne(x => x.Name)
            .Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .OwnsOne(x => x.Name)
            .Property(x => x.LastName)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(x => x.OrderLimit)
            .IsRequired()
            .MoneyConversion();
    }
}
