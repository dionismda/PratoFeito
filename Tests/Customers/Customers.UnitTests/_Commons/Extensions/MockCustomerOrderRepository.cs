namespace Customers.UnitTests._Commons.Extensions;

public static class MockCustomerOrderRepository
{
    public static void SetupGetAllAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, List<CustomerOrder> customerOrders)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetAllAsync(It.IsAny<GetCustomerOrderAllSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerOrders);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void VerifyGetAllAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, Func<Times> times)
    {
        mockCustomerOrderRepository
            .Verify(x => x.GetAllAsync(It.IsAny<GetCustomerOrderAllSpecification>(), It.IsAny<CancellationToken>()), times);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void SetupGetByIdAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, CustomerOrder customerOrder)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<GetCustomerOrderByIdSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerOrder);

        mockCustomerOrderRepository.SetupAllProperties();
    }

    public static void VerifyGetByIdAsync(this Mock<ICustomerOrderRepository> mockCustomerOrderRepository, Func<Times> times)
    {
        mockCustomerOrderRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<GetCustomerOrderByIdSpecification>(), It.IsAny<CancellationToken>()), times);

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
