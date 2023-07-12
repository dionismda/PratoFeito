namespace Customers.UnitTests.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandHandlerTest
{
    private CreateCustomerCommandHandler CreateCustomerCommandHandler { get; set; }
    private Customer Customer { get; set; }

    private readonly Mock<IMapper> mockMapper = new();
    private readonly Mock<ICustomerDomainService> mockCustomerDomainService = new();

    public CreateCustomerCommandHandlerTest()
    {
        CreateCustomerCommandHandler = new CreateCustomerCommandHandler(mockMapper.Object, mockCustomerDomainService.Object);
        Customer = CustomerBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommandData.ValidCreateCustomerCommand), MemberType = typeof(CreateCustomerCommandData))]
    public async Task CreateCustomerCommandHandler_MustReturnCustomerObecjt_WhenCreateCustomerCommandIsCalled(CreateCustomerCommand createCustomerCommand)
    {
        mockMapper.SetupMap<CreateCustomerCommand, Customer>(Customer);

        var result = await CreateCustomerCommandHandler.Handle(createCustomerCommand, It.IsAny<CancellationToken>());

        mockMapper.VerifyMap<CreateCustomerCommand, Customer>(Times.Once);

        mockCustomerDomainService
            .Verify(x => x.InsertAsync(Customer, It.IsAny<CancellationToken>()), Times.Once);

        Assert.Equal(Customer, result);
    }
}
