namespace Customers.UnitTests.Application.Customers.Commands.DeleteCustomers;

public sealed class DeleteUpdateCommandHandlerTest
{
    private DeleteUpdateCommandHandler DeleteUpdateCommandHandler { get; set; }

    private readonly Mock<ICustomerDomainService> mockCustomerDomainService = new();

    public DeleteUpdateCommandHandlerTest()
    {
        DeleteUpdateCommandHandler = new DeleteUpdateCommandHandler(mockCustomerDomainService.Object);
    }

    [Theory]
    [MemberData(nameof(DeleteCustomerOrderCommandData.ValidDeleteCustomerOrderCommand), MemberType = typeof(DeleteCustomerOrderCommandData))]
    public async Task DeleteUpdateCommandHandler_MustDeleteObject_WhenDeleteCustomerOrderCommandIsCalled(DeleteCustomerOrderCommand command)
    {
        await DeleteUpdateCommandHandler.Handle(command, It.IsAny<CancellationToken>());

        mockCustomerDomainService
            .Verify(x => x.DeleteAsync(It.IsAny<GetCustomerByIdSpecification>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
