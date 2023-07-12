namespace Customers.UnitTests.Application.Customers.Queries.GetCustomers;

public sealed class GetCustomersQueryHandlerTest
{
    private GetCustomersQueryHandler GetCustomersQueryHandler { get; set; }
    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();

    public GetCustomersQueryHandlerTest()
    {
        GetCustomersQueryHandler = new GetCustomersQueryHandler(mockCustomerRepository.Object);
    }

    [Theory]
    [MemberData(nameof(GetCustomersQueryData.ValidGetCustomersQuery), MemberType = typeof(GetCustomersQueryData))]
    public async Task GetCustomersQueryHandler_MustReturnAListOfCustomer_WhenGetCustomersQueryIsCalled(GetCustomersQuery getCustomersQuery)
    {
        mockCustomerRepository.SetupGetAllAsync(new List<Customer>()
        {
            CustomerBuilder.New().Build()
        });

        var result = await GetCustomersQueryHandler.Handle(getCustomersQuery, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetAllAsync(Times.Once);

        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}
