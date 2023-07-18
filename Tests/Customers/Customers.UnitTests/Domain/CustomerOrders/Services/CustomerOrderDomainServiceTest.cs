namespace Customers.UnitTests.Domain.CustomerOrders.Services;

public sealed class CustomerOrderDomainServiceTest
{
    private CustomerOrder CustomerOrder { get; set; }
    private CustomerOrderDomainService CustomerOrderDomainService { get; set; }
    private readonly Mock<ICustomerOrderRepository> mockCustomerOrderRepository = new();

    public CustomerOrderDomainServiceTest()
    {
        CustomerOrderDomainService = new CustomerOrderDomainService(mockCustomerOrderRepository.Object);
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
        mockCustomerOrderRepository.SetupGetAllAsync(new List<CustomerOrder>());

        await CustomerOrderDomainService.GetCustomerOrderAllAsync(It.IsAny<CancellationToken>());

        mockCustomerOrderRepository.VerifyGetAllAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustReturnACustomerOrder()
    {
        mockCustomerOrderRepository.SetupGetByIdAsync(CustomerOrder);

        await CustomerOrderDomainService.GetCustomerOrderByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>());

        mockCustomerOrderRepository.VerifyGetByIdAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustInsertData_WhenObjectIsValid()
    {
        mockCustomerOrderRepository
            .Setup(x => x.Insert(CustomerOrder));

        mockCustomerOrderRepository.SetupCommitAsync();

        await CustomerOrderDomainService.InsertAsync(CustomerOrder, It.IsAny<CancellationToken>());

        mockCustomerOrderRepository
            .Verify(x => x.Insert(CustomerOrder), Times.Once);

        mockCustomerOrderRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustUpdateData_WhenObjectIsValid()
    {
        mockCustomerOrderRepository
            .Setup(x => x.Update(CustomerOrder));

        mockCustomerOrderRepository.SetupCommitAsync();

        await CustomerOrderDomainService.UpdateAsync(CustomerOrder, It.IsAny<CancellationToken>());

        mockCustomerOrderRepository
            .Verify(x => x.Update(CustomerOrder), Times.Once);

        mockCustomerOrderRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerOrderDomainService_MustDeleteData_WhenObjectExists()
    {
        mockCustomerOrderRepository.SetupGetByIdAsync(CustomerOrder);

        mockCustomerOrderRepository
            .Setup(x => x.Delete(CustomerOrder));

        mockCustomerOrderRepository.SetupCommitAsync();

        await CustomerOrderDomainService.DeleteAsync(new GetCustomerOrderByIdSpecification(CustomerOrder.Id), It.IsAny<CancellationToken>());

        mockCustomerOrderRepository.VerifyGetByIdAsync(Times.Once);

        mockCustomerOrderRepository
            .Verify(x => x.Delete(CustomerOrder), Times.Once);

        mockCustomerOrderRepository.VerifyCommitAsync(Times.Once);
    }
}
