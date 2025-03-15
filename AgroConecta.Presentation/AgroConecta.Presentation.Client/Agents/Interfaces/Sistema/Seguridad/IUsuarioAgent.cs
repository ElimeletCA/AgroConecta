using AgroConecta.Shared.Seguridad;

namespace AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Seguridad;

public interface IUsuarioAgent: IBaseAgent<UsuarioDTO>
{
    Task<IEnumerable<UsuarioDTO>> GetAllExcept(string email);
}