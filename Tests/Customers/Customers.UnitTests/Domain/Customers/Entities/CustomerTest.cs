﻿namespace Customers.UnitTests.Domain.Customers.Entities;

public sealed class CustomerTest
{
    private Customer Customer { get; set; }

    public CustomerTest()
    {
        Customer = CustomerBuilder.New().Build();
    }

    [Fact]
    public void Customer_MustCreateObject_WhenIsValid()
    {
        Assert.NotNull(Customer);
        Assert.NotEmpty(Customer.DomainEvents.OfType<CustomerCreatedDomainEvent>());
    }

    [Theory]
    [MemberData(nameof(PersonNameData.ValidPersonName), MemberType = typeof(PersonNameData))]
    public void Customer_MustCreateObject_WhenNameIsChanged(PersonName validName)
    {
        Customer.ChangeName(validName);

        Assert.NotNull(Customer);
        Assert.Equal(Customer.Name, validName);
        Assert.NotEmpty(Customer.DomainEvents.OfType<CustomerNameUpdatedDomainEvent>());
    }

    [Theory]
    [MemberData(nameof(MoneyData.ValidMoney), MemberType = typeof(MoneyData))]
    public void Customer_MustCreateObject_WhenOrderLimitIsChanged(Money validMoney)
    {
        Customer.ChangeOrderLimit(validMoney);

        Assert.NotNull(Customer);
        Assert.Equal(Customer.OrderLimit, validMoney);
        Assert.NotEmpty(Customer.DomainEvents.OfType<CustomerOrderLimitUpdatedDomainEvent>());
    }
}