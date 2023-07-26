namespace Customers.UnitTests._Commons.Extensions;

public static class MockCustomerOrderRepositoryExtension
{
    public static void SetupGetCustomerOrderAllAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, List<CustomerOrder> customerOrders)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetCustomerOrderAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerOrders);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void VerifyGetCustomerOrderAllAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, Func<Times> times)
    {
        mockCustomerOrderRepository
            .Verify(x => x.GetCustomerOrderAllAsync(It.IsAny<CancellationToken>()), times);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void SetupGetCustomerOrderByIdAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, CustomerOrder customerOrder)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerOrder);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void VerifyGetCustomerOrderByIdAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, Func<Times> times)
    {
        mockCustomerOrderRepository
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), times);

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
