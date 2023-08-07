using _Architecture.Domain.Abstractions;

namespace _Architecture.UnitTests.Domain.Services;

public sealed class NotificationDomainServiceTest
{
    private NotificationDomainService NotificationDomainService { get; set; } = new();

    public NotificationDomainServiceTest()
    {
    }

    [Fact]
    public void NotificationDomainService_MustCretedObject_WhenItIsInitialized()
    {
        Assert.NotNull(NotificationDomainService);
        Assert.True(!NotificationDomainService.HasError());
    }

    [Fact]
    public void NotificationDomainService_MustAddError_WhenAddErrorMethodIsCalled()
    {
        NotificationDomainService.AddError("index", "errorMessage");

        Assert.True(NotificationDomainService.HasError());
    }

    [Fact]
    public void NotificationDomainService_MustClearListOfError_WhenClearErrorListMethodIsCalled()
    {
        NotificationDomainService.AddError("index", "errorMessage");
        Assert.True(NotificationDomainService.HasError());
        NotificationDomainService.ClearErrorList();
        Assert.True(!NotificationDomainService.HasError());
    }

    [Fact]
    public void NotificationDomainService_MustReturnException_WhenValidateMethodIsCalledAndHasError()
    {
        NotificationDomainService.AddError("index", "errorMessage");

        Assert.Throws<NotificationDomainException>(() => NotificationDomainService.Validate("messageError"));
    }
}
