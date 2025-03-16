namespace AgroConecta.Application.Servicios.Interfaces.Seguridad;

public interface IBaseService<T>
{
    Task<T> CreateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}