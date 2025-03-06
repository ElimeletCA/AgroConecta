using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AgroConecta.Application.Constantes.Seguridad;
using AgroConecta.Domain.System.Seguridad;

namespace AgroConecta.Application.Seeds;

public static class DefaultUsers
    {
        public static async Task SembrarUsuarioAdministradorAsync(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, string passworddefaultuser)
        {
            var defaultUser = new Usuario()
            {
                UserName = "Elimelet",
                nombre_completo = "Elimelet Caraballo Abad",
                Email = "elimelet.dev@gmail.com",
                EmailConfirmed = true,
                TwoFactorEnabled = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, passworddefaultuser);
                    await userManager.AddToRoleAsync(defaultUser, Roles.Administrador.ToString());
                }
                await roleManager.SembrarClaimsParaAdministrador();
            }
        }
        private async static Task SembrarClaimsParaAdministrador(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Administrador");
            await roleManager.AgregarClaimPermisoYModulo(adminRole, "Terrenos");
            await roleManager.AgregarClaimPermisoYModulo(adminRole, "Arrendamientos");
            await roleManager.AgregarClaimPermisoYModulo(adminRole, "Proyectos");
            await roleManager.AgregarClaimPermisoYModulo(adminRole, "Roles");
            await roleManager.AgregarClaimPermisoYModulo(adminRole, "Usuarios");

        }
        public static async Task AgregarClaimPermisoYModulo(this RoleManager<IdentityRole> roleManager, IdentityRole role, string modulo)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermisos = Permisos.GenerarPermisosParaModulo(modulo);
            foreach (var permiso in allPermisos)
            {
                if (!allClaims.Any(a => a.Type == "Permiso" && a.Value == permiso))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permiso", permiso));
                }
            }
        }
    }