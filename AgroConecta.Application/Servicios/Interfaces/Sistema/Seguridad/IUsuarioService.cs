using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Shared.Seguridad;

namespace AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;

public interface IUsuarioService : IBaseService
{
    Task<IEnumerable<UsuarioDTO>> GetAllExceptAsync(string email);

}