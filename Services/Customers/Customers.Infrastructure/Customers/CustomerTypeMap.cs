namespace Customers.Infrastructure.Customers;

public sealed class CustomerTypeMap : AggregateTypeMap<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder
            .OwnsOne(x => x.Name)
            .Property(x => x.FirstName)
            .HasColumnName("firstname")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .OwnsOne(x => x.Name)
            .Property(x => x.LastName)
            .HasColumnName("lastname")
            .HasMaxLength(200)
            .IsRequired();

        builder.OwnsOne(x => x.Name, n =>
        {
            n.Property(x => x.FirstName)
             .HasColumnName("firstname")
             .HasMaxLength(55)
             .IsRequired();

            n.Property(x => x.LastName)
             .HasColumnName("lastname")
             .HasMaxLength(200)
             .IsRequired();

            n.HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();
        });

        builder
            .Property(x => x.OrderLimit)
            .HasColumnName("order_limit")
            .IsRequired()
            .MoneyConversion();
    }
}
