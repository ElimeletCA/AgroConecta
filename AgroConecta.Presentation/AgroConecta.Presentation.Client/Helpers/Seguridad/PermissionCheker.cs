using System.Security.Claims;

namespace AgroConecta.Presentation.Client.Helpers.Seguridad;

public static class PermissionCheker
{
    public static bool TienePermiso(ClaimsPrincipal usuario,  string permiso)
    {
        return usuario?.Claims.Any(c => c.Type == "Permiso" && c.Value == permiso) ?? false;
    }
    public static bool TieneRol(ClaimsPrincipal usuario,  string rol)
    {
        return usuario?.Claims.Any(c => c.Type == "Role" && c.Value == rol) ?? false;
    }
}