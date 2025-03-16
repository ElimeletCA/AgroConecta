using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.Seguridad;

namespace AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> GetAllExceptAsync(string email);
    Task<UsuarioDTO> GetByIdAsync(string id);
    Task<bool> DeleteAsync(string id);

}