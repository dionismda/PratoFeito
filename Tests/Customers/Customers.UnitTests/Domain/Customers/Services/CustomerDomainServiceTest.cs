namespace Customers.UnitTests.Domain.Customers.Services;

public sealed class CustomerDomainServiceTest
{
    private Customer Customer { get; set; }
    private CustomerDomainService CustomerDomainService { get; set; }
    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();
    private readonly Mock<INotificationDomainService> mockNotificationDomainService = new();

    public CustomerDomainServiceTest()
    {
        CustomerDomainService = new CustomerDomainService(mockNotificationDomainService.Object, mockCustomerRepository.Object);
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
        mockCustomerRepository.SetupGetAllAsync(new List<Customer>());

        await CustomerDomainService.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>());

        mockCustomerRepository.VerifyGetAllAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustReturnACustomer()
    {
        mockCustomerRepository.SetupGetByIdAsync(Customer);

        await CustomerDomainService.GetByIdAsync(It.IsAny<Identifier>(), It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetByIdAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustInsertData_WhenObjectIsValid()
    {
        mockCustomerRepository.SetupGetAllAsync(new List<Customer>());

        mockCustomerRepository
            .Setup(x => x.Insert(Customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.InsertAsync(Customer, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetAllAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Insert(Customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateData_WhenObjectIsValid()
    {
        var customer = CustomerBuilder.New().Build();

        mockCustomerRepository.SetupGetAllAsync(new List<Customer>());

        mockCustomerRepository.SetupGetByIdAsync(customer);

        mockCustomerRepository
            .Setup(x => x.Update(customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetAllAsync(Times.Once);

        mockCustomerRepository.VerifyGetByIdAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Update(customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateDataReturnException_WhenObjectNotFound()
    {
        mockCustomerRepository.SetupGetAllAsync(new List<Customer>());

        mockCustomerRepository.SetupGetByIdAsync(It.IsAny<Customer>());

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());
        });

        mockCustomerRepository.VerifyGetAllAsync(Times.Once);

        mockCustomerRepository.VerifyGetByIdAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustDeleteData_WhenObjectExists()
    {
        mockCustomerRepository.SetupGetByIdAsync(Customer);

        mockCustomerRepository
            .Setup(x => x.Delete(Customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.DeleteAsync(Customer.Id, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetByIdAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Delete(Customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_ValidateFieldsMustNotReturnException_WhenNameNotExists()
    {
        mockCustomerRepository.SetupGetAllAsync(new List<Customer>
            {
                    new Customer(PersonNameBuilder.New().Build(), MoneyBuilder.New().Build()),
                    new Customer(PersonNameBuilder.New().Build(), MoneyBuilder.New().Build())
            });

        Func<Task<IList<Customer>>> getResultQueryValidate = ()
            => mockCustomerRepository.Object.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null);

        await CustomerDomainService.ValidateFields(getResultQueryValidate, Customer);

        mockNotificationDomainService.VerifyAddError(Times.Never);

        mockNotificationDomainService.VerifyValidate(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_ValidateFieldsMustReturnException_WhenNameExists()
    {
        mockCustomerRepository.SetupGetAllAsync(new List<Customer>
            {
                    Customer,
                    new Customer(PersonNameBuilder.New().Build(), MoneyBuilder.New().Build())
            });

        Func<Task<IList<Customer>>> getResultQueryValidate = ()
            => mockCustomerRepository.Object.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<Expression<Func<Customer, bool>>>(), null, null, null);

        mockNotificationDomainService.SetupThrows();

        await Assert.ThrowsAsync<NotificationDomainException>(async () =>
        {
            await CustomerDomainService.ValidateFields(getResultQueryValidate, Customer);
        });

        mockNotificationDomainService.VerifyAddError(Times.Once);

        mockNotificationDomainService.VerifyValidate(Times.Once);
    }
}