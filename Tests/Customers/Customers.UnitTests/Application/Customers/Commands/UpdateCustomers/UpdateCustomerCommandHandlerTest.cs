namespace Customers.UnitTests.Application.Customers.Commands.UpdateCustomers;

public class UpdateCustomerCommandHandlerTest
{
    private UpdateCustomerCommandHandler UpdateCustomerCommandHandler { get; set; }

    private readonly Mock<ICustomerDomainService> mockCustomerDomainService = new();

    public UpdateCustomerCommandHandlerTest()
    {
        UpdateCustomerCommandHandler = new UpdateCustomerCommandHandler(mockCustomerDomainService.Object);
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommandData.ValidUpdateCustomerCommand), MemberType = typeof(UpdateCustomerCommandData))]
    public async Task UpdateCustomerCommandHandler_MustReturnCustomerObecjtUpdated_WhenUpdateCustomerCommandDataIsCalled(UpdateCustomerCommand updateCustomerCommand)
    {
        await UpdateCustomerCommandHandler.Handle(updateCustomerCommand, It.IsAny<CancellationToken>());

        mockCustomerDomainService
            .Verify(x => x.UpdateAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
