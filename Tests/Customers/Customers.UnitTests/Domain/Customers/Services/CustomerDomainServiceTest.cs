namespace Customers.UnitTests.Domain.Customers.Services;

public sealed class CustomerDomainServiceTest
{
    private Customer Customer { get; set; }
    private CustomerDomainService CustomerDomainService { get; set; }
    private readonly Mock<ICustomerRepository> customerRepository = new();
    private readonly Mock<INotificationDomainService> notificationDomainService = new();

    public CustomerDomainServiceTest()
    {
        CustomerDomainService = new CustomerDomainService(notificationDomainService.Object, customerRepository.Object);
        Customer = CustomerBuilder.New().Build();
    }

    [Fact]
    public void CustomerDomainService_MustCreated_WhenParamsIsValid()
    {
        Assert.NotNull(CustomerDomainService);
    }

    [Fact]
    public async Task CustomerDomainService_MustReturnAListOfCustomers()
    {
        customerRepository
            .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null))
            .ReturnsAsync(new List<Customer>());

        await CustomerDomainService.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>());

        customerRepository
            .Verify(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null), Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustReturnACustomer()
    {
        customerRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Customer);

        await CustomerDomainService.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>());

        customerRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustInsertData_WhenObjectIsValid()
    {
        customerRepository
            .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null))
            .ReturnsAsync(new List<Customer>());

        customerRepository
            .Setup(x => x.Insert(Customer));

        customerRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        await CustomerDomainService.InsertAsync(Customer, It.IsAny<CancellationToken>());

        customerRepository
            .Verify(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null), Times.Once);

        customerRepository
            .Verify(x => x.Insert(Customer), Times.Once);

        customerRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateData_WhenObjectIsValid()
    {
        var customer = CustomerBuilder.New().Build();

        customerRepository
            .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null))
            .ReturnsAsync(new List<Customer>());

        customerRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        customerRepository
            .Setup(x => x.Update(customer));

        customerRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());

        customerRepository
            .Verify(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null), Times.Once);

        customerRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        customerRepository
            .Verify(x => x.Update(customer), Times.Once);

        customerRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateDataReturnException_WhenObjectNotFound()
    {
        customerRepository
            .Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null))
            .ReturnsAsync(new List<Customer>());

        customerRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(It.IsAny<Customer>());

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());
        });

        customerRepository
            .Verify(x => x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null), Times.Once);

        customerRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustDeleteData_WhenObjectExists()
    {
        customerRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Customer);

        customerRepository
            .Setup(x => x.Delete(Customer));

        customerRepository
            .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()));

        await CustomerDomainService.DeleteAsync(Customer.Id, It.IsAny<CancellationToken>());

        customerRepository
            .Verify(x => x.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>()), Times.Once);

        customerRepository
            .Verify(x => x.Delete(Customer), Times.Once);

        customerRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
