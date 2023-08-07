namespace Customers.UnitTests.Application.CustomerOrders.Commands.CreateCustomerOrder;

public sealed class CreateCustomerOrderCommandHandlerTest
{
    private CreateCustomerOrderCommandHandler CreateCustomerOrderCommandHandler { get; set; }
    private readonly Mock<ICustomerOrderRepository> mockCustomerOrderRepository = new();
    public CreateCustomerOrderCommandHandlerTest()
    {
        CreateCustomerOrderCommandHandler = new CreateCustomerOrderCommandHandler(mockCustomerOrderRepository.Object);
    }

    [Theory]
    [MemberData(nameof(CreateCustomerOrderCommandData.ValidCreateCustomerOrderCommand), MemberType = typeof(CreateCustomerOrderCommandData))]
    public async Task CreateCustomerCommandHandler_MustReturnCustomerObecjt_WhenCreateCustomerCommandIsCalled(CreateCustomerOrderCommand createCustomerOrderCommand)
    {
        await CreateCustomerOrderCommandHandler.Handle(createCustomerOrderCommand, It.IsAny<CancellationToken>());

        mockCustomerOrderRepository
            .Verify(x => x.Insert(It.IsAny<CustomerOrder>()), Times.Once);

        mockCustomerOrderRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
