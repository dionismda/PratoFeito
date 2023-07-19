namespace Customers.UnitTests.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryHandlerTest
{
    private GetCustomerByIdQueryHandler GetCustomerByIdQueryHandler { get; set; }
    private readonly Mock<ICustomerQueries> mockCustomerQueries = new();

    public GetCustomerByIdQueryHandlerTest()
    {
        GetCustomerByIdQueryHandler = new GetCustomerByIdQueryHandler(mockCustomerQueries.Object);
    }

    [Theory]
    [MemberData(nameof(GetCustomerByIdQueryData.ValidGetCustomerByIdQuery), MemberType = typeof(GetCustomerByIdQueryData))]
    public async Task GetCustomerByIdQueryHandler_MustReturnCustomerObecjt_WhenCustomerIdExists(GetCustomerByIdQuery getCustomerByIdQuery)
    {
        mockCustomerQueries.SetupGetCustomerByIdAsync(new GetCustomerByIdQueryModel());

        var result = await GetCustomerByIdQueryHandler.Handle(getCustomerByIdQuery, It.IsAny<CancellationToken>());

        mockCustomerQueries.VerifyGetCustomerByIdAsync(Times.Once);

        Assert.NotNull(result);
    }

    [Theory]
    [MemberData(nameof(GetCustomerByIdQueryData.ValidGetCustomerByIdQuery), MemberType = typeof(GetCustomerByIdQueryData))]
    public async Task GetCustomerByIdQueryHandler_MustReturnNull_WhenCustomerIdNotExists(GetCustomerByIdQuery getCustomerByIdQuery)
    {
        mockCustomerQueries.SetupGetCustomerByIdAsync(It.IsAny<GetCustomerByIdQueryModel>());

        var result = await GetCustomerByIdQueryHandler.Handle(getCustomerByIdQuery, It.IsAny<CancellationToken>());

        mockCustomerQueries.VerifyGetCustomerByIdAsync(Times.Once);

        Assert.Null(result);
    }
}
