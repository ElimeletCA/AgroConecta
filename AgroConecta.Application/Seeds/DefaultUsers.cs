using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.Constantes.Seguridad;

namespace AgroConecta.Application.Seeds;

public static class DefaultUsers
    {
        public static async Task SembrarUsuarioAdministradorAsync(
            UserManager<Usuario> userManager,
            RoleManager<IdentityRole> roleManager,
            string emaildefaultuser,
            string passworddefaultuser)
        {
            var defaultUser = new Usuario()
            {
                UserName = "Administrador",
                nombre_completo = "Administrador",
                Email = emaildefaultuser,
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
        public static async Task SembrarUsuariosDummyAsync(
            UserManager<Usuario> userManager, int cantidad)
        {
            for (int i = 1; i <= cantidad; i++)
            {
                string username = $"dummy{i}";
                string email = $"{username}@example.com";
                string password = email; 

                var dummyUser = new Usuario()
                {
                    UserName = username,
                    nombre_completo = username,
                    Email = email,
                    EmailConfirmed = true,
                    TwoFactorEnabled = false
                };

                if (userManager.Users.All(u => u.Email != dummyUser.Email))
                {
                    var user = await userManager.FindByEmailAsync(dummyUser.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(dummyUser, password);
                    }
                }
            }
        }
        

    }