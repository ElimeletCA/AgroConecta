namespace AgroConecta.Infrastructure.Repositorios.Interfaces;

public interface IRepository<T, TId>
{
    Task<T> InsertAsync(T entity);
    
    Task<T?> GetByIdAsync(TId id);
    
    Task<IQueryable<T>> GetAllAsync();
    
    void UpdateAsync(T entity);
    
    Task<bool> SoftDeleteAsync(TId id);
    
    Task<bool> HardDeleteAsync(TId id);

}