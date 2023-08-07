namespace Customers.UnitTests.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandHandlerTest
{
    private CreateCustomerCommandHandler CreateCustomerCommandHandler { get; set; }

    private readonly Mock<ICustomerDomainService> mockCustomerDomainService = new();

    public CreateCustomerCommandHandlerTest()
    {
        CreateCustomerCommandHandler = new CreateCustomerCommandHandler(mockCustomerDomainService.Object);
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommandData.ValidCreateCustomerCommand), MemberType = typeof(CreateCustomerCommandData))]
    public async Task CreateCustomerCommandHandler_MustReturnCustomerObecjt_WhenCreateCustomerCommandIsCalled(CreateCustomerCommand createCustomerCommand)
    {
        await CreateCustomerCommandHandler.Handle(createCustomerCommand, It.IsAny<CancellationToken>());

        mockCustomerDomainService
            .Verify(x => x.InsertAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
