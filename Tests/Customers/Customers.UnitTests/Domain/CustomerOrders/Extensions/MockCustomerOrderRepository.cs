namespace Customers.UnitTests.Domain.CustomerOrders.Extensions;

public static class MockCustomerOrderRepository
{
    public static void SetupGetAllAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, List<CustomerOrder> customerOrders)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetAllAsync(
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<CustomerOrder, bool>>>(),
                It.IsAny<Func<IQueryable<CustomerOrder>, IOrderedQueryable<CustomerOrder>>>(),
                It.IsAny<int?>(),
                It.IsAny<int?>(),
                It.IsAny<string[]?>()))
            .ReturnsAsync(customerOrders);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void VerifyGetAllAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, Func<Times> times)
    {
        mockCustomerOrderRepository
            .Verify(
                x => x.GetAllAsync(
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<CustomerOrder, bool>>>(),
                It.IsAny<Func<IQueryable<CustomerOrder>, IOrderedQueryable<CustomerOrder>>>(),
                It.IsAny<int?>(),
                It.IsAny<int?>(),
                It.IsAny<string[]?>()),
                times);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void SetupGetByIdAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, CustomerOrder customerOrder)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerOrder);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void VerifyGetByIdAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, Func<Times> times)
    {
        mockCustomerOrderRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), times);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void SetupCommitAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository)
    {
        mockCustomerOrderRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void VerifyCommitAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, Func<Times> times)
    {
        mockCustomerOrderRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), times);

        mockCustomerOrderRepository.SetupAllProperties();
    }
}
