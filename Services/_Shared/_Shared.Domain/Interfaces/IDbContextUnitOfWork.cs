namespace _Shared.Domain.Interfaces;

public interface IDbContextUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
