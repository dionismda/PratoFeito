namespace _Architecture.UnitTests.Domain.Extensions;

public static class MockCustomerNotificationDomainServiceExtension
{
    public static void SetupThrows(this Mock<ICustomerNotificationDomainService> mockNotificationDomainService)
    {
        mockNotificationDomainService
             .Setup(x => x.Validate(It.IsAny<string>()))
             .Throws(new NotificationDomainException(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>()));

        mockNotificationDomainService.SetupAllProperties();
    }

    public static void VerifyAddError(this Mock<ICustomerNotificationDomainService> mockNotificationDomainService, Func<Times> times)
    {
        mockNotificationDomainService
            .Verify(x => x.AddError(It.IsAny<string>(), It.IsAny<string>()), times);

        mockNotificationDomainService.SetupAllProperties();
    }

    public static void VerifyValidate(this Mock<ICustomerNotificationDomainService> mockNotificationDomainService, Func<Times> times)
    {
        mockNotificationDomainService
            .Verify(x => x.Validate(It.IsAny<string>()), times);

        mockNotificationDomainService.SetupAllProperties();
    }

}
