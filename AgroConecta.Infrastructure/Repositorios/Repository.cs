using AgroConecta.Infrastructure.Repositorios.Interfaces;

namespace AgroConecta.Infrastructure.Repositorios;

public class Repository<T, TId> : IRepository<T, TId>
{
    public Task<T> InsertAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SoftDeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HardDeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }
}