using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;

public interface ISeguridadAgent : IBaseAgent<UsuarioDTO>
{
    Task<ApiResponse<BackendMessage>> RegisterUser(UsuarioDTO usuario);

    Task<ApiResponse<BackendMessage>> LoginUser(UsuarioDTO usuario);
    Task<ApiResponse<BackendMessage>> Verificar2FA(UsuarioDTO usuario);

}