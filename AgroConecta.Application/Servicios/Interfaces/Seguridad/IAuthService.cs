using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.DTO.Seguridad;
using AgroConecta.Shared.Seguridad;
using Microsoft.AspNetCore.Http;

namespace AgroConecta.Application.Servicios.Interfaces.Seguridad;

public interface IAuthService
{
    Task<bool> RegistrarUsuario(UsuarioDTO usuario);
    Task<bool> GenerarCorreoDeConfirmacion(UsuarioDTO usuario);
    Task<bool> ConfirmarCorreo(string token, string email);


    Task<string> GenerarTokenString(Usuario usuario);

    Task<bool> LoginUsuario(UsuarioDTO usuario);

    public bool ExisteTokenValido(HttpContext context);
    public void EliminarJwtTokenDeCookie(HttpContext context);

}