using AgroConecta.Domain.General;

namespace AgroConecta.Infrastructure.Repositorios.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    // Obtiene una entidad por su ID
    Task<T?> GetByIdAsync(string id);
    
    // Obtiene todas las entidades (usualmente filtrando los eliminados lógicamente)
    Task<IEnumerable<T>> GetAllAsync();
    
    // Agrega una nueva entidad
    Task AddAsync(T entity);
    
    // Actualiza una entidad existente
    void Update(T entity);
    
    // Realiza un soft delete marcando la entidad como eliminada
    Task SoftDeleteAsync(T entity);
    
    // Realiza un hard delete eliminando la entidad de forma permanente
    Task HardDeleteAsync(T entity);
}