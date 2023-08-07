namespace Customers.UnitTests.Application.CustomerOrders.Commands.CreateCustomerOrder;

public sealed class CreateCustomerOrderCommandHandlerTest
{
    private CreateCustomerOrderCommandHandler CreateCustomerOrderCommandHandler { get; set; }
    private CustomerOrder CustomerOrder { get; set; }

    private readonly Mock<ICustomerOrderDomainService> mockCustomerOrderDomainService = new();
    public CreateCustomerOrderCommandHandlerTest()
    {
        CreateCustomerOrderCommandHandler = new CreateCustomerOrderCommandHandler(mockCustomerOrderDomainService.Object);
        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(CreateCustomerOrderCommandData.ValidCreateCustomerOrderCommand), MemberType = typeof(CreateCustomerOrderCommandData))]
    public async Task CreateCustomerCommandHandler_MustReturnCustomerObecjt_WhenCreateCustomerCommandIsCalled(CreateCustomerOrderCommand createCustomerOrderCommand)
    {
        await CreateCustomerOrderCommandHandler.Handle(createCustomerOrderCommand, It.IsAny<CancellationToken>());

        mockCustomerOrderDomainService
            .Verify(x => x.InsertAsync(It.IsAny<CustomerOrder>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
