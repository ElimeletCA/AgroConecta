namespace AgroConecta.Presentation.Seguridad;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

public class RequierePermisoAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _permisoRequerido;

    public RequierePermisoAttribute(string permisoRequerido)
    {
        _permisoRequerido = permisoRequerido;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Si el usuario no está autenticado, se devuelve un resultado no autorizado.
        if (!context.HttpContext.User.Identity!.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // Se busca si el usuario posee el claim "Permiso" con el valor requerido.
        var tienePermiso = context.HttpContext.User.Claims
            .Any(c => c.Type == "Permiso" && c.Value == _permisoRequerido);

        if (!tienePermiso)
        {
            // Si no tiene el permiso, se devuelve Forbidden.
            context.Result = new ForbidResult();
        }
    }
}
