﻿namespace _Architecture.UnitTests.Domain.ValueObjects.Helpers;

public static class MoneyData
{
    public static IEnumerable<object[]> InvalidMoney =>
        new List<object[]>
        {
            new[] { MoneyBuilder.New().ChangeAmount(100).Build() },
            new[] { MoneyBuilder.New().ChangeAmount(1000).Build() },
            new[] { MoneyBuilder.New().ChangeAmount(10000).Build() },
        };

    public static IEnumerable<object[]> ValidMoney =>
        new List<object[]>
        {
            new[] { MoneyBuilder.New().Build() },
            new[] { MoneyBuilder.New().Build() },
            new[] { MoneyBuilder.New().Build() },
        };
}