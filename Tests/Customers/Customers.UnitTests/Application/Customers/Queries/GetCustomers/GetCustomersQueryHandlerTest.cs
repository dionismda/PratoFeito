namespace Customers.UnitTests.Application.Customers.Queries.GetCustomers;

public sealed class GetCustomersQueryHandlerTest
{
    private GetCustomersQueryHandler GetCustomersQueryHandler { get; set; }
    private readonly Mock<ICustomerQueries> mockCustomerQueries = new();

    public GetCustomersQueryHandlerTest()
    {
        GetCustomersQueryHandler = new GetCustomersQueryHandler(mockCustomerQueries.Object);
    }

    [Theory]
    [MemberData(nameof(GetCustomersQueryData.ValidGetCustomersQuery), MemberType = typeof(GetCustomersQueryData))]
    public async Task GetCustomersQueryHandler_MustReturnAListOfCustomer_WhenGetCustomersQueryIsCalled(GetCustomersQuery getCustomersQuery)
    {
        mockCustomerQueries.SetupGetCustomersAsync(new List<GetCustomersQueryModel>()
        {
            new GetCustomersQueryModel()
        });

        var result = await GetCustomersQueryHandler.Handle(getCustomersQuery, It.IsAny<CancellationToken>());

        mockCustomerQueries.VerifyGetCustomersAsync(Times.Once);

        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}
