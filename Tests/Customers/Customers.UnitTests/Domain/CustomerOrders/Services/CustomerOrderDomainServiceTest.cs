using Moq;

namespace Customers.UnitTests.Domain.CustomerOrders.Services;

public sealed class CustomerOrderDomainServiceTest
{
    private CustomerOrder CustomerOrder { get; set; }
    private CustomerOrderDomainService CustomerOrderDomainService { get; set; }
    private readonly Mock<ICustomerOrderRepository> customerOrderRepository = new();

    public CustomerOrderDomainServiceTest()
    {
        CustomerOrderDomainService = new CustomerOrderDomainService(customerOrderRepository.Object);
        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Fact]
    public void CustomerOrderDomainService_MustCreated_WhenParamsIsValid()
    {
        Assert.NotNull(CustomerOrder);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustReturnAListOfCustomerOrder()
    {
        customerOrderRepository
            .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<CustomerOrder, bool>>>(), null, null, null))
            .ReturnsAsync(new List<CustomerOrder>());

        await CustomerOrderDomainService.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<CustomerOrder, bool>>>());

        customerOrderRepository
            .Verify(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<CustomerOrder, bool>>>(), null, null, null), Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustReturnACustomerOrder()
    {
        customerOrderRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerOrder);

        await CustomerOrderDomainService.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>());

        customerOrderRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustInsertData_WhenObjectIsValid()
    {
        customerOrderRepository
            .Setup(x => x.Insert(CustomerOrder));

        customerOrderRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        await CustomerOrderDomainService.InsertAsync(CustomerOrder, It.IsAny<CancellationToken>());

        customerOrderRepository
            .Verify(x => x.Insert(CustomerOrder), Times.Once);

        customerOrderRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustUpdateData_WhenObjectIsValid()
    {
        customerOrderRepository
            .Setup(x => x.Update(CustomerOrder));

        customerOrderRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        await CustomerOrderDomainService.UpdateAsync(CustomerOrder, It.IsAny<CancellationToken>());

        customerOrderRepository
            .Verify(x => x.Update(CustomerOrder), Times.Once);

        customerOrderRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustDeleteData_WhenObjectExists()
    {
        customerOrderRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerOrder);

        customerOrderRepository
            .Setup(x => x.Delete(CustomerOrder));

        customerOrderRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        await CustomerOrderDomainService.DeleteAsync(CustomerOrder.Id, It.IsAny<CancellationToken>());

        customerOrderRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        customerOrderRepository
            .Verify(x => x.Delete(CustomerOrder), Times.Once);

        customerOrderRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
