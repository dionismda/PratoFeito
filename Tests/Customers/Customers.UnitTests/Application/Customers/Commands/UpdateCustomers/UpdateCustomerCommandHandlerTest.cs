namespace Customers.UnitTests.Application.Customers.Commands.UpdateCustomers;

public class UpdateCustomerCommandHandlerTest
{
    private UpdateCustomerCommandHandler UpdateCustomerCommandHandler { get; set; }
    private Customer Customer { get; set; }

    private readonly Mock<IMapper> mockMapper = new();
    private readonly Mock<ICustomerDomainService> mockCustomerDomainService = new();

    public UpdateCustomerCommandHandlerTest()
    {
        UpdateCustomerCommandHandler = new UpdateCustomerCommandHandler(mockMapper.Object, mockCustomerDomainService.Object);
        Customer = CustomerBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommandData.ValidUpdateCustomerCommand), MemberType = typeof(UpdateCustomerCommandData))]
    public async Task UpdateCustomerCommandHandler_MustReturnCustomerObecjtUpdated_WhenUpdateCustomerCommandDataIsCalled(UpdateCustomerCommand updateCustomerCommand)
    {
        mockMapper.SetupMap<UpdateCustomerCommand, Customer>(Customer);

        var result = await UpdateCustomerCommandHandler.Handle(updateCustomerCommand, It.IsAny<CancellationToken>());

        mockMapper.VerifyMap<UpdateCustomerCommand, Customer>(Times.Once);

        mockCustomerDomainService
            .Verify(x => x.UpdateAsync(Customer, It.IsAny<CancellationToken>()), Times.Once);

        Assert.Equal(Customer, result);
    }
}
