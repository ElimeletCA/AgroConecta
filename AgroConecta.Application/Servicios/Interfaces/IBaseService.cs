using AgroConecta.Domain.General;
using AgroConecta.Shared.DTO;

namespace AgroConecta.Application.Servicios.Interfaces;

public interface IBaseService<TDto, TEntity>
    where TEntity : BaseEntity
    where TDto : BaseDTO
{
    Task<TDto?> GetByIdAsync(string id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task AddAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task SoftDeleteAsync(string id);
    Task HardDeleteAsync(string id);
}