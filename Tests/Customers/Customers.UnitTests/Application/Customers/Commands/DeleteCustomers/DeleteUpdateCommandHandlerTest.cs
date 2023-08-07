namespace Customers.UnitTests.Application.Customers.Commands.DeleteCustomers;

public sealed class DeleteUpdateCommandHandlerTest
{
    private DeleteUpdateCommandHandler DeleteUpdateCommandHandler { get; set; }
    private Customer Customer { get; set; }

    private readonly Mock<ICustomerRepository> mockCustomerRepository = new();

    public DeleteUpdateCommandHandlerTest()
    {
        DeleteUpdateCommandHandler = new DeleteUpdateCommandHandler(mockCustomerRepository.Object);
        Customer = CustomerBuilder.New().Build();
    }

    [Theory]
    [MemberData(nameof(DeleteCustomerOrderCommandData.ValidDeleteCustomerOrderCommand), MemberType = typeof(DeleteCustomerOrderCommandData))]
    public async Task DeleteUpdateCommandHandler_MustDeleteObject_WhenDeleteCustomerOrderCommandIsCalled(DeleteCustomerOrderCommand command)
    {
        mockCustomerRepository.SetupGetCustomerByIdAsync(Customer);

        await DeleteUpdateCommandHandler.Handle(command, It.IsAny<CancellationToken>());

        mockCustomerRepository.VerifyGetCustomerByIdAsync(Times.Once);

        mockCustomerRepository
            .Verify(x => x.Delete(It.IsAny<Customer>()), Times.Once);

        mockCustomerRepository
            .Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [MemberData(nameof(DeleteCustomerOrderCommandData.ValidDeleteCustomerOrderCommand), MemberType = typeof(DeleteCustomerOrderCommandData))]
    public async Task DeleteUpdateCommandHandler_MustReturnException_WhenDeleteCustomerOrderCommandIsCalledAndCustomerOrderIdNotExists(DeleteCustomerOrderCommand command)
    {
        mockCustomerRepository.SetupGetCustomerByIdAsync(It.IsAny<Customer>());

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await DeleteUpdateCommandHandler.Handle(command, It.IsAny<CancellationToken>());
        });

        mockCustomerRepository.VerifyGetCustomerByIdAsync(Times.Once);
    }
}
