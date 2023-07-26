namespace Customers.UnitTests._Commons.Extensions;

public static class MockCustomerRepositoryExtension
{
    public static void SetupGetCustomerAllAsync(this Mock<ICustomerRepository> mockCustomerRepository, List<Customer> customers)
    {
        mockCustomerRepository
            .Setup(x => x.GetCustomerAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(customers);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void VerifyGetCustomerAllAsync(this Mock<ICustomerRepository> mockCustomerRepository, Func<Times> times)
    {
        mockCustomerRepository
            .Verify(x => x.GetCustomerAllAsync(It.IsAny<CancellationToken>()), times);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void SetupGetCustomerByIdAsync(this Mock<ICustomerRepository> mockCustomerRepository, Customer customer)
    {
        mockCustomerRepository
            .Setup(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void VerifyGetCustomerByIdAsync(this Mock<ICustomerRepository> mockCustomerRepository, Func<Times> times)
    {
        mockCustomerRepository
            .Verify(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), times);

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

    public static void SetupGetCustomerDuplicateAsync(this Mock<ICustomerRepository> mockCustomerRepository, List<Customer> customer)
    {
        mockCustomerRepository
            .Setup(x => x.GetCustomerDuplicateAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        mockCustomerRepository.SetupAllProperties();
    }

    public static void VerifyGetCustomerDuplicateAsync(this Mock<ICustomerRepository> mockCustomerRepository, Func<Times> times)
    {
        mockCustomerRepository
            .Verify(x => x.GetCustomerDuplicateAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()), times);

        mockCustomerRepository.SetupAllProperties();
    }
}
