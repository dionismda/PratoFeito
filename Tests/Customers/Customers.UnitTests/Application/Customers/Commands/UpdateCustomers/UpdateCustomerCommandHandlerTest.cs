namespace Customers.UnitTests.Application.Customers.Commands.UpdateCustomers;

public class UpdateCustomerCommandHandlerTest
{
    private UpdateCustomerCommandHandler UpdateCustomerCommandHandler { get; set; }
    private Customer Customer { get; set; }

    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();

    public UpdateCustomerCommandHandlerTest()
    {
        UpdateCustomerCommandHandler = new UpdateCustomerCommandHandler(mockCustomerRepository.Object);
        Customer = CustomerBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommandData.ValidUpdateCustomerCommand), MemberType = typeof(UpdateCustomerCommandData))]
    public async Task UpdateCustomerCommandHandler_MustReturnCustomerObecjtUpdated_WhenUpdateCustomerCommandDataIsCalled(UpdateCustomerCommand updateCustomerCommand)
    {
        mockCustomerRepository.SetupGetCustomerByIdAsync(Customer);

        await UpdateCustomerCommandHandler.Handle(updateCustomerCommand, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetCustomerByIdAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Update(It.IsAny<Customer>()), Times.Once);

        mockCustomerRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
