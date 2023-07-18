namespace Customers.UnitTests.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryHandlerTest
{
    private GetCustomerByIdQueryHandler GetCustomerByIdQueryHandler { get; set; }
    private Customer Customer { get; set; }
    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();

    public GetCustomerByIdQueryHandlerTest()
    {
        GetCustomerByIdQueryHandler = new GetCustomerByIdQueryHandler(mockCustomerRepository.Object);
        Customer = CustomerBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(GetCustomerByIdQueryData.ValidGetCustomerByIdQuery), MemberType = typeof(GetCustomerByIdQueryData))]
    public async Task GetCustomerByIdQueryHandler_MustReturnCustomerObecjt_WhenCustomerIdExists(GetCustomerByIdQuery getCustomerByIdQuery)
    {
        mockCustomerRepository.SetupGetByIdAsync(Customer);

        var result = await GetCustomerByIdQueryHandler.Handle(getCustomerByIdQuery, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetByIdAsync(Times.Once);

        Assert.Equal(Customer, result);
    }

    [Theory]
    [MemberData(nameof(GetCustomerByIdQueryData.ValidGetCustomerByIdQuery), MemberType = typeof(GetCustomerByIdQueryData))]
    public async Task GetCustomerByIdQueryHandler_MustReturnNull_WhenCustomerIdNotExists(GetCustomerByIdQuery getCustomerByIdQuery)
    {
        mockCustomerRepository.SetupGetByIdAsync(It.IsAny<Customer>());

        var result = await GetCustomerByIdQueryHandler.Handle(getCustomerByIdQuery, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetByIdAsync(Times.Once);

        Assert.Null(result);
    }
}
