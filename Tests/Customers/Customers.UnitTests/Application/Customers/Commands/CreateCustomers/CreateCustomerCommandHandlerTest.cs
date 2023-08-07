namespace Customers.UnitTests.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandHandlerTest
{
    private CreateCustomerCommandHandler CreateCustomerCommandHandler { get; set; }

    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();

    public CreateCustomerCommandHandlerTest()
    {
        CreateCustomerCommandHandler = new CreateCustomerCommandHandler(mockCustomerRepository.Object);
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommandData.ValidCreateCustomerCommand), MemberType = typeof(CreateCustomerCommandData))]
    public async Task CreateCustomerCommandHandler_MustReturnCustomerObecjt_WhenCreateCustomerCommandIsCalled(CreateCustomerCommand createCustomerCommand)
    {
        await CreateCustomerCommandHandler.Handle(createCustomerCommand, It.IsAny<CancellationToken>());

        mockCustomerRepository
            .Verify(x => x.Insert(It.IsAny<Customer>()), Times.Once);

        mockCustomerRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
