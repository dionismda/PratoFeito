namespace Customers.UnitTests.Domain.Customers.Services;

public sealed class CustomerDomainServiceTest
{
    private Customer Customer { get; set; }
    private CustomerDomainService CustomerDomainService { get; set; }
    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();
    private readonly Mock<ICustomerNotificationDomainService> mockCustomerNotificationDomainService = new();

    public CustomerDomainServiceTest()
    {
        CustomerDomainService = new CustomerDomainService(mockCustomerNotificationDomainService.Object, mockCustomerRepository.Object);
        Customer = CustomerBuilder.New().Build();
    }

    [Fact]
    public void CustomerDomainService_MustCreated_WhenParamsIsValid()
    {
        Assert.NotNull(CustomerDomainService);
    }

    [Fact]
    public async Task CustomerDomainService_MustInsertData_WhenObjectIsValid()
    {
        mockCustomerRepository.SetupGetCustomerDuplicateAsync(new List<Customer>());

        mockCustomerRepository
            .Setup(x => x.Insert(Customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.InsertAsync(Customer, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetCustomerDuplicateAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Insert(Customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateData_WhenObjectIsValid()
    {
        var customer = CustomerBuilder.New().Build();

        mockCustomerRepository.SetupGetCustomerDuplicateAsync(new List<Customer>());

        mockCustomerRepository.SetupGetCustomerByIdAsync(customer);

        mockCustomerRepository
            .Setup(x => x.Update(customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetCustomerDuplicateAsync(Times.Once);

        mockCustomerRepository.VerifyGetCustomerByIdAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Update(customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateDataReturnException_WhenObjectNotFound()
    {
        mockCustomerRepository.SetupGetCustomerDuplicateAsync(new List<Customer>());

        mockCustomerRepository.SetupGetCustomerByIdAsync(It.IsAny<Customer>());

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());
        });

        mockCustomerRepository.VerifyGetCustomerDuplicateAsync(Times.Once);

        mockCustomerRepository.VerifyGetCustomerByIdAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustDeleteData_WhenObjectExists()
    {
        mockCustomerRepository
            .Setup(x => x.Delete(Customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.DeleteAsync(Customer, It.IsAny<CancellationToken>());

        mockCustomerRepository
            .Verify(x => x.Delete(Customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_ValidateFieldsMustNotReturnException_WhenNameNotExists()
    {
        mockCustomerRepository.SetupGetCustomerDuplicateAsync(new List<Customer>
            {
                    new Customer(PersonNameBuilder.New().Build(), MoneyBuilder.New().Build()),
                    new Customer(PersonNameBuilder.New().Build(), MoneyBuilder.New().Build())
            });

        Func<Task<IList<Customer>>> getResultQueryValidate = ()
            => mockCustomerRepository.Object.GetCustomerDuplicateAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>());

        await CustomerDomainService.ValidateFields(getResultQueryValidate, Customer);

        mockCustomerNotificationDomainService.VerifyAddError(Times.Never);

        mockCustomerNotificationDomainService.VerifyValidate(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_ValidateFieldsMustReturnException_WhenNameExists()
    {
        mockCustomerRepository.SetupGetCustomerDuplicateAsync(new List<Customer>
            {
                    Customer,
                    new Customer(PersonNameBuilder.New().Build(), MoneyBuilder.New().Build())
            });

        Func<Task<IList<Customer>>> getResultQueryValidate = ()
            => mockCustomerRepository.Object.GetCustomerDuplicateAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>());

        mockCustomerNotificationDomainService.SetupThrows();

        await Assert.ThrowsAsync<NotificationDomainException>(async () =>
        {
            await CustomerDomainService.ValidateFields(getResultQueryValidate, Customer);
        });

        mockCustomerNotificationDomainService.VerifyAddError(Times.Once);

        mockCustomerNotificationDomainService.VerifyValidate(Times.Once);
    }
}