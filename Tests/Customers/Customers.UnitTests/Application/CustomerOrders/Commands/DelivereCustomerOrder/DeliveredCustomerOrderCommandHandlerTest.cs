namespace Customers.UnitTests.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public sealed class DeliveredCustomerOrderCommandHandlerTest
{
    private DeliveredCustomerOrderCommandHandler DeliveredCustomerOrderCommandHandler { get; set; }
    private CustomerOrder CustomerOrder { get; set; }

    private readonly Mock<ICustomerOrderRepository> mockCustomerOrderRepository = new();

    public DeliveredCustomerOrderCommandHandlerTest()
    {
        DeliveredCustomerOrderCommandHandler = new DeliveredCustomerOrderCommandHandler(mockCustomerOrderRepository.Object);
        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(DeliveredCustomerOrderCommandData.ValidDeliveredCustomerOrderCommand), MemberType = typeof(DeliveredCustomerOrderCommandData))]
    public async Task DeliveredCustomerOrderCommand_MustReturnCustomerOrderObecjtDelivered_WhenDeliveredCustomerOrderCommandIsCalledAndCustomerOrderIsValid(DeliveredCustomerOrderCommand deliveredCustomerOrderCommand)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerOrder);

        mockCustomerOrderRepository
            .Setup(x => x.Update(It.IsAny<CustomerOrder>()));

        var result = await DeliveredCustomerOrderCommandHandler.Handle(deliveredCustomerOrderCommand, It.IsAny<CancellationToken>());

        mockCustomerOrderRepository
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        mockCustomerOrderRepository
            .Verify(x => x.Update(It.IsAny<CustomerOrder>()), Times.Once);

        mockCustomerOrderRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(result);
        Assert.True(result.State == CustomerOrderState.Delivered);
    }

    [Theory]
    [MemberData(nameof(DeliveredCustomerOrderCommandData.ValidDeliveredCustomerOrderCommand), MemberType = typeof(DeliveredCustomerOrderCommandData))]
    public async Task CancelCustomerOrderCommandHandler_MustReturnNotFoundException_WhenDeliveredCustomerOrderCommandIsCalledAndCustomerOrderNotExists(DeliveredCustomerOrderCommand deliveredCustomerOrderCommand)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(It.IsAny<CustomerOrder>());

        await Assert.ThrowsAsync<NotFoundException>(async ()
            => await DeliveredCustomerOrderCommandHandler.Handle(deliveredCustomerOrderCommand, It.IsAny<CancellationToken>()));

        mockCustomerOrderRepository
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
