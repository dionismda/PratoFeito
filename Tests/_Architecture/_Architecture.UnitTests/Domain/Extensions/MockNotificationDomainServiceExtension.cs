namespace _Architecture.UnitTests.Domain.Extensions;

public static class MockNotificationDomainServiceExtension
{
    public static void SetupThrows(this Mock<INotificationDomainService> mockNotificationDomainService)
    {
        mockNotificationDomainService
             .Setup(x => x.Validate(It.IsAny<string>()))
             .Throws(new NotificationDomainException(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>()));

        mockNotificationDomainService.SetupAllProperties();
    }

    public static void VerifyAddError(this Mock<INotificationDomainService> mockNotificationDomainService, Func<Times> times)
    {
        mockNotificationDomainService
            .Verify(x => x.AddError(It.IsAny<string>(), It.IsAny<string>()), times);

        mockNotificationDomainService.SetupAllProperties();
    }

    public static void VerifyValidate(this Mock<INotificationDomainService> mockNotificationDomainService, Func<Times> times)
    {
        mockNotificationDomainService
            .Verify(x => x.Validate(It.IsAny<string>()), times);

        mockNotificationDomainService.SetupAllProperties();
    }

}
