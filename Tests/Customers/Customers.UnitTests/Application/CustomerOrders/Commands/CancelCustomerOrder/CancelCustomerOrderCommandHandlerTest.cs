namespace Customers.UnitTests.Application.CustomerOrders.Commands.CancelCustomerOrder;

public sealed class CancelCustomerOrderCommandHandlerTest
{
    private CancelCustomerOrderCommandHandler CancelCustomerOrderCommandHandler { get; set; }
    private CustomerOrder CustomerOrder { get; set; }

    private readonly Mock<ICustomerOrderRepository> mockCustomerOrderRepository = new();

    public CancelCustomerOrderCommandHandlerTest()
    {
        CancelCustomerOrderCommandHandler = new CancelCustomerOrderCommandHandler(mockCustomerOrderRepository.Object);

        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(CancelCustomerOrderCommandData.ValidCancelCustomerOrderCommand), MemberType = typeof(CancelCustomerOrderCommandData))]
    public async Task CancelCustomerOrderCommandHandler_MustReturnCustomerOrderObecjtCanceled_WhenCancelCustomerOrderCommandIsCalledAndCustomerOrderIsValid(CancelCustomerOrderCommand cancelCustomerOrderCommand)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerOrder);

        mockCustomerOrderRepository
            .Setup(x => x.Update(It.IsAny<CustomerOrder>()));

        var result = await CancelCustomerOrderCommandHandler.Handle(cancelCustomerOrderCommand, It.IsAny<CancellationToken>());

        mockCustomerOrderRepository
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        mockCustomerOrderRepository
            .Verify(x => x.Update(It.IsAny<CustomerOrder>()), Times.Once);

        mockCustomerOrderRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(result);
        Assert.True(result.State == CustomerOrderState.Cancelled);
    }

    [Theory]
    [MemberData(nameof(CancelCustomerOrderCommandData.ValidCancelCustomerOrderCommand), MemberType = typeof(CancelCustomerOrderCommandData))]
    public async Task CancelCustomerOrderCommandHandler_MustReturnNotFoundException_WhenCancelCustomerOrderCommandIsCalledAndCustomerOrderNotExists(CancelCustomerOrderCommand cancelCustomerOrderCommand)
    {
        mockCustomerOrderRepository
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(It.IsAny<CustomerOrder>());

        await Assert.ThrowsAsync<NotFoundException>(async ()
            => await CancelCustomerOrderCommandHandler.Handle(cancelCustomerOrderCommand, It.IsAny<CancellationToken>()));

        mockCustomerOrderRepository
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
