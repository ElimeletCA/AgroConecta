using AgroConecta.Domain.System.Seguridad;
using Microsoft.AspNetCore.Http;

namespace AgroConecta.Application.Servicios.Interfaces.Seguridad;

public interface IAuthService
{
    Task<string> GenerarTokenString(Usuario usuario);
    Task<bool> LoginUsuario(Usuario usuario);
    Task<bool> RegistrarUsuario(Usuario usuario);
    public void ColocarJwtTokenEnCookie(string token, HttpContext context);
    public bool ExisteTokenValido(HttpContext context);
    public void EliminarJwtTokenDeCookie(HttpContext context);

}