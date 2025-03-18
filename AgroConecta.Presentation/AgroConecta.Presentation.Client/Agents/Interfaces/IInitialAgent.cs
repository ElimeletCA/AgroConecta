using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Client.Agents.Interfaces;

public interface IInitialAgent<TDto> : IBaseAgent
    where TDto : BaseDTO
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(string id);
    Task<bool> AddAsync(TDto dto);
    Task UpdateAsync(string id, TDto dto);
    Task SoftDeleteAsync(string id);
    Task HardDeleteAsync(string id);
}