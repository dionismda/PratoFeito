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
        mockCustomerQueries
            .Setup(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new GetCustomerByIdQueryModel());

        var result = await GetCustomerByIdQueryHandler.Handle(getCustomerByIdQuery, It.IsAny<CancellationToken>());

        mockCustomerQueries
            .Verify(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(result);
    }

    [Theory]
    [MemberData(nameof(GetCustomerByIdQueryData.ValidGetCustomerByIdQuery), MemberType = typeof(GetCustomerByIdQueryData))]
    public async Task GetCustomerByIdQueryHandler_MustReturnNull_WhenCustomerIdNotExists(GetCustomerByIdQuery getCustomerByIdQuery)
    {
        mockCustomerQueries
            .Setup(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(It.IsAny<GetCustomerByIdQueryModel>());

        var result = await GetCustomerByIdQueryHandler.Handle(getCustomerByIdQuery, It.IsAny<CancellationToken>());

        mockCustomerQueries
            .Verify(x => x.GetCustomerByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.Null(result);
    }
}
