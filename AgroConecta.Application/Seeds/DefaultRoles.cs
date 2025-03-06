
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AgroConecta.Application.Constantes.Seguridad;
using AgroConecta.Domain.System.Seguridad;

namespace AgroConecta.Application.Seeds;

public static class DefaultRoles
{
    public static async Task SembrarAsync(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Administrador.ToString()));
    }
}