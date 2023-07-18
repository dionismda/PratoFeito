namespace Customers.UnitTests.Application.CustomerOrders.Commands.CreateCustomerOrder;

public sealed class CreateCustomerOrderCommandHandlerTest
{
    private CreateCustomerOrderCommandHandler CreateCustomerOrderCommandHandler { get; set; }
    private CustomerOrder CustomerOrder { get; set; }

    private readonly Mock<IMapper> mockMapper = new();
    private readonly Mock<ICustomerOrderDomainService> mockCustomerOrderDomainService = new();
    public CreateCustomerOrderCommandHandlerTest()
    {
        CreateCustomerOrderCommandHandler = new CreateCustomerOrderCommandHandler(mockMapper.Object, mockCustomerOrderDomainService.Object);
        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(CreateCustomerOrderCommandData.ValidCreateCustomerOrderCommand), MemberType = typeof(CreateCustomerOrderCommandData))]
    public async Task CreateCustomerCommandHandler_MustReturnCustomerObecjt_WhenCreateCustomerCommandIsCalled(CreateCustomerOrderCommand createCustomerOrderCommand)
    {
        mockMapper.SetupMap<CreateCustomerOrderCommand, CustomerOrder>(CustomerOrder);

        var result = await CreateCustomerOrderCommandHandler.Handle(createCustomerOrderCommand, It.IsAny<CancellationToken>());

        mockMapper.VerifyMap<CreateCustomerOrderCommand, CustomerOrder>(Times.Once);

        mockCustomerOrderDomainService
            .Verify(x => x.InsertAsync(CustomerOrder, It.IsAny<CancellationToken>()), Times.Once);

        Assert.Equal(CustomerOrder, result);
    }
}
