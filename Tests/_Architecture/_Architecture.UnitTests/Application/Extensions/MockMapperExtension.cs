namespace _Architecture.UnitTests.Application.Extensions;

public static class MockMapperExtension
{
    public static void SetupMap<TSource, TDestination>(this Mock<IMapper> mockMapper, TDestination destination)
    {
        mockMapper
            .Setup(x => x.Map<TDestination>(It.IsAny<TSource>()))
            .Returns(destination);

        mockMapper.SetupAllProperties();
    }

    public static void VerifyMap<TSource, TDestination>(this Mock<IMapper> mockMapper, Func<Times> times)
    {
        mockMapper
            .Verify(x => x.Map<TDestination>(It.IsAny<TSource>()), times);

        mockMapper.SetupAllProperties();
    }
}
