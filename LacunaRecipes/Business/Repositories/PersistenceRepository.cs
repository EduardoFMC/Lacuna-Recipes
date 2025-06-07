using Microsoft.EntityFrameworkCore.Storage;
using LacunaRecipes.Entities;

namespace LacunaRecipes.Business.Repositories;

public class PersistenceRepository : IPersistenceRepository
{
    private readonly AppDbContext dbContext;

    public PersistenceRepository(
        AppDbContext dbContext
        )
    {
        this.dbContext = dbContext;
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
    }

    public async Task RollbackTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
    }

    public async Task TransactionAsync(Func<Task> action)
    {
        using var transaction = await BeginTransactionAsync();
        try
        {
            await action();
            await SaveChangesAsync();
            await CommitTransactionAsync(transaction);
        }
        catch
        {
            await RollbackTransactionAsync(transaction);
            throw;
        }
    }

    public async Task<T> TransactionAsync<T>(Func<Task<T>> action)
    {
        using var transaction = await BeginTransactionAsync();
        try
        {
            var res = await action();
            await SaveChangesAsync();
            await CommitTransactionAsync(transaction);
            return res;
        }
        catch
        {
            await RollbackTransactionAsync(transaction);
            throw;
        }
    }
}
