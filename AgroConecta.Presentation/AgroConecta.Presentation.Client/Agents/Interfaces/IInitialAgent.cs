using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Client.Agents.Interfaces;

public interface IInitialAgent<TDto> : IBaseAgent
    where TDto : BaseDTO
{
    Task<IEnumerable<TDto>> GetAllAsync(string[] includes = null);
    Task<TDto?> GetByIdAsync(string id, string[] includes = null);
    Task<bool> AddAsync(TDto dto);
    Task<string> AddWithIdAsync(TDto dto);
    Task UpdateAsync(string id, TDto dto);
    Task SoftDeleteAsync(string id);
    Task HardDeleteAsync(string id);
}