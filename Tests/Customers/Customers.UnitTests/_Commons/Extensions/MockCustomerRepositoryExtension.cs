namespace Customers.UnitTests._Commons.Extensions;

public static class MockCustomerRepositoryExtension
{
    public static void SetupGetAllAsync(this Mock<ICustomerRepository> mockCustomerRepository, List<Customer> customers)
    {
        mockCustomerRepository
            .Setup(x => x.GetAllAsync(It.IsAny<GetCustomerAllSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customers);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void VerifyGetAllAsync(this Mock<ICustomerRepository> mockCustomerRepository, Func<Times> times)
    {
        mockCustomerRepository
            .Verify(x => x.GetAllAsync(It.IsAny<GetCustomerAllSpecification>(), It.IsAny<CancellationToken>()), times);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void SetupGetByIdAsync(this Mock<ICustomerRepository> mockCustomerRepository, Customer customer)
    {
        mockCustomerRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<GetCustomerByIdSpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void VerifyGetByIdAsync(this Mock<ICustomerRepository> mockCustomerRepository, Func<Times> times)
    {
        mockCustomerRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<GetCustomerByIdSpecification>(), It.IsAny<CancellationToken>()), times);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void SetupCommitAsync(this Mock<ICustomerRepository> mockCustomerRepository)
    {
        mockCustomerRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        mockCustomerRepository.SetupAllProperties();
    }

    public static void VerifyCommitAsync(this Mock<ICustomerRepository> mockCustomerRepository, Func<Times> times)
    {
        mockCustomerRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), times);

        mockCustomerRepository.SetupAllProperties();
    }
}
