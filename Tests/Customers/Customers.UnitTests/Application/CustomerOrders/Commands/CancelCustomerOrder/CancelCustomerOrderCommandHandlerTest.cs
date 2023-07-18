namespace Customers.UnitTests.Application.CustomerOrders.Commands.CancelCustomerOrder;

public sealed class CancelCustomerOrderCommandHandlerTest
{
    private CancelCustomerOrderCommandHandler CancelCustomerOrderCommandHandler { get; set; }
    private CustomerOrder CustomerOrder { get; set; }

    private readonly Mock<ICustomerOrderDomainService> mockCustomerOrderDomainService = new();

    public CancelCustomerOrderCommandHandlerTest()
    {
        CancelCustomerOrderCommandHandler = new CancelCustomerOrderCommandHandler(mockCustomerOrderDomainService.Object);
        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(CancelCustomerOrderCommandData.ValidCancelCustomerOrderCommand), MemberType = typeof(CancelCustomerOrderCommandData))]
    public async Task CancelCustomerOrderCommandHandler_MustReturnCustomerOrderObecjtCanceled_WhenCancelCustomerOrderCommandIsCalledAndCustomerOrderIsValid(CancelCustomerOrderCommand cancelCustomerOrderCommand)
    {
        mockCustomerOrderDomainService
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerOrder);

        mockCustomerOrderDomainService
            .Setup(x => x.UpdateAsync(It.IsAny<CustomerOrder>(), It.IsAny<CancellationToken>()));

        var result = await CancelCustomerOrderCommandHandler.Handle(cancelCustomerOrderCommand, It.IsAny<CancellationToken>());

        mockCustomerOrderDomainService
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        mockCustomerOrderDomainService
            .Verify(x => x.UpdateAsync(It.IsAny<CustomerOrder>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(result);
        Assert.True(result.State == CustomerOrderState.Cancelled);
    }

    [Theory]
    [MemberData(nameof(CancelCustomerOrderCommandData.ValidCancelCustomerOrderCommand), MemberType = typeof(CancelCustomerOrderCommandData))]
    public async Task CancelCustomerOrderCommandHandler_MustReturnNotFoundException_WhenCancelCustomerOrderCommandIsCalledAndCustomerOrderNotExists(CancelCustomerOrderCommand cancelCustomerOrderCommand)
    {
        mockCustomerOrderDomainService
            .Setup(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(It.IsAny<CustomerOrder>());

        await Assert.ThrowsAsync<NotFoundException>(async ()
            => await CancelCustomerOrderCommandHandler.Handle(cancelCustomerOrderCommand, It.IsAny<CancellationToken>()));

        mockCustomerOrderDomainService
            .Verify(x => x.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
