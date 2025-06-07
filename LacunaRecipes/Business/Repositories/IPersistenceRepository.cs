using Microsoft.EntityFrameworkCore.Storage;

namespace LacunaRecipes.Business.Repositories;

public interface IPersistenceRepository
{
    public Task SaveChangesAsync();

    public Task<IDbContextTransaction> BeginTransactionAsync();

    public Task CommitTransactionAsync(IDbContextTransaction transaction);

    public Task RollbackTransactionAsync(IDbContextTransaction transaction);

    public Task TransactionAsync(Func<Task> action);

    public Task<T> TransactionAsync<T>(Func<Task<T>> action);
}
