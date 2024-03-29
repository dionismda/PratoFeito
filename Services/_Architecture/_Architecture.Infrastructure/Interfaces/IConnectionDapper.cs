﻿namespace _Architecture.Infrastructure.Interfaces;

public interface IConnectionDapper
{
    Task<IDbConnection> GetConnectionAsync(string? schema = null);
}
