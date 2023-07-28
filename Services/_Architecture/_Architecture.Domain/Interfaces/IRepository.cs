namespace _Architecture.Domain.Interfaces;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
    Task CommitAsync(CancellationToken cancellationToken);
}
