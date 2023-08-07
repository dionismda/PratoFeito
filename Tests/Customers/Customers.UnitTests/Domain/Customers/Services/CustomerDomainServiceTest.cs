namespace Customers.UnitTests.Domain.Customers.Services;

public sealed class CustomerDomainServiceTest
{
    private Customer Customer { get; set; }
    private CustomerDomainService CustomerDomainService { get; set; }
    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();

    public CustomerDomainServiceTest()
    {
        CustomerDomainService = new CustomerDomainService(mockCustomerRepository.Object);
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
        mockCustomerRepository
            .Setup(x => x.Insert(Customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.InsertAsync(Customer, It.IsAny<CancellationToken>());

        mockCustomerRepository
            .Verify(x => x.Insert(Customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateData_WhenObjectIsValid()
    {
        var customer = CustomerBuilder.New().Build();

        mockCustomerRepository.SetupGetCustomerByIdAsync(customer);

        mockCustomerRepository
            .Setup(x => x.Update(customer));

        mockCustomerRepository.SetupCommitAsync();

        await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetCustomerByIdAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Update(customer), Times.Once);

        mockCustomerRepository.VerifyCommitAsync(Times.Once);
    }

    [Fact]
    public async Task CustomerDomainService_MustUpdateDataReturnException_WhenObjectNotFound()
    {
        mockCustomerRepository.SetupGetCustomerByIdAsync(It.IsAny<Customer>());

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await CustomerDomainService.UpdateAsync(Customer, It.IsAny<CancellationToken>());
        });

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
}