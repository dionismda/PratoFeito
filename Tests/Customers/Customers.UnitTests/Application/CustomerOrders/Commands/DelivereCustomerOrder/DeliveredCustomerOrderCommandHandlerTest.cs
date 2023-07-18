namespace Customers.UnitTests.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public sealed class DeliveredCustomerOrderCommandHandlerTest
{
    private DeliveredCustomerOrderCommandHandler DeliveredCustomerOrderCommandHandler { get; set; }
    private CustomerOrder CustomerOrder { get; set; }

    private readonly Mock<ICustomerOrderDomainService> mockCustomerOrderDomainService = new();

    public DeliveredCustomerOrderCommandHandlerTest()
    {
        DeliveredCustomerOrderCommandHandler = new DeliveredCustomerOrderCommandHandler(mockCustomerOrderDomainService.Object);
        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(DeliveredCustomerOrderCommandData.ValidDeliveredCustomerOrderCommand), MemberType = typeof(DeliveredCustomerOrderCommandData))]
    public async Task DeliveredCustomerOrderCommand_MustReturnCustomerOrderObecjtDelivered_WhenDeliveredCustomerOrderCommandIsCalledAndCustomerOrderIsValid(DeliveredCustomerOrderCommand deliveredCustomerOrderCommand)
    {
        mockCustomerOrderDomainService
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerOrder);

        mockCustomerOrderDomainService
            .Setup(x => x.UpdateAsync(It.IsAny<CustomerOrder>(), It.IsAny<CancellationToken>()));

        var result = await DeliveredCustomerOrderCommandHandler.Handle(deliveredCustomerOrderCommand, It.IsAny<CancellationToken>());

        mockCustomerOrderDomainService
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        mockCustomerOrderDomainService
            .Verify(x => x.UpdateAsync(It.IsAny<CustomerOrder>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(result);
        Assert.True(result.State == CustomerOrderState.Delivered);
    }

    [Theory]
    [MemberData(nameof(DeliveredCustomerOrderCommandData.ValidDeliveredCustomerOrderCommand), MemberType = typeof(DeliveredCustomerOrderCommandData))]
    public async Task CancelCustomerOrderCommandHandler_MustReturnNotFoundException_WhenDeliveredCustomerOrderCommandIsCalledAndCustomerOrderNotExists(DeliveredCustomerOrderCommand deliveredCustomerOrderCommand)
    {
        mockCustomerOrderDomainService
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(It.IsAny<CustomerOrder>());

        await Assert.ThrowsAsync<NotFoundException>(async ()
            => await DeliveredCustomerOrderCommandHandler.Handle(deliveredCustomerOrderCommand, It.IsAny<CancellationToken>()));

        mockCustomerOrderDomainService
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
