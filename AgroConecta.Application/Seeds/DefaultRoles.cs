
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.Constantes.Seguridad;

namespace AgroConecta.Application.Seeds;

public static class DefaultRoles
{
    public static async Task SembrarAsync(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Administrador.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Propietario.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Agricultor.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Inversionista.ToString()));



    }
}