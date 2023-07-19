namespace Customers.UnitTests._Commons.Extensions;

public static class MockCustomerQueriesExtension
{

    public static void SetupGetCustomersAsync(
        this Mock<ICustomerQueries> mockCustomerQueries,
        List<GetCustomersQueryModel> getCustomersQueryModel)
    {
        mockCustomerQueries
            .Setup(x => x.GetCustomersAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(getCustomersQueryModel);

        mockCustomerQueries.SetupAllProperties();
    }

    public static void VerifyGetCustomersAsync(this Mock<ICustomerQueries> mockCustomerQueries, Func<Times> times)
    {
        mockCustomerQueries
            .Verify(x => x.GetCustomersAsync(It.IsAny<CancellationToken>()), times);

        mockCustomerQueries.SetupAllProperties();
    }

    public static void SetupGetCustomerByIdAsync(this Mock<ICustomerQueries> mockCustomerQueries, GetCustomerByIdQueryModel getCustomerByIdQueryModel)
    {
        mockCustomerQueries
            .Setup(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(getCustomerByIdQueryModel);

        mockCustomerQueries.SetupAllProperties();
    }

    public static void VerifyGetCustomerByIdAsync(this Mock<ICustomerQueries> mockCustomerQueries, Func<Times> times)
    {
        mockCustomerQueries
            .Verify(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), times);

        mockCustomerQueries.SetupAllProperties();
    }

    public static void SetupGetCustomerOrdersByCustomerIdAsync(
        this Mock<ICustomerQueries> mockCustomerQueries,
        List<GetCustomerOrdersByCustomerIdQueryModel> getCustomerOrdersByCustomerIdQueryModel)
    {
        mockCustomerQueries
            .Setup(x => x.GetCustomerOrdersByCustomerIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(getCustomerOrdersByCustomerIdQueryModel);

        mockCustomerQueries.SetupAllProperties();
    }

    public static void VerifyGetCustomerOrdersByCustomerIdAsync(this Mock<ICustomerQueries> mockCustomerQueries, Func<Times> times)
    {
        mockCustomerQueries
            .Verify(x => x.GetCustomerOrdersByCustomerIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), times);

        mockCustomerQueries.SetupAllProperties();
    }
}
