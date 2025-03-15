using Microsoft.AspNetCore.Authorization;
namespace AgroConecta.Presentation.Seguridad;

public class RequisitoPermiso : IAuthorizationRequirement
{
    public string Permiso { get; private set; }
    public RequisitoPermiso(string permiso)
    {
        Permiso = permiso;
    }
}