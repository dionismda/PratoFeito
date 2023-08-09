namespace Customers.UnitTests._Commons.Extensions;

public static class MockCustomerRepositoryExtension
{
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
}
