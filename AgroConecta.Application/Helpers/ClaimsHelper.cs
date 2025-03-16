using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Security.Claims;
using AgroConecta.Application.ViewModels;
using AgroConecta.Shared.DTO;

namespace AgroConecta.Application.Helpers;

public static class ClaimsHelper
{
    public static void ObtenerPermisos(this List<FuncionesRolDTO> allPermissions, Type policy, string roleId)
    {
        FieldInfo[] fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);
        foreach (FieldInfo fi in fields)
        {
            allPermissions.Add(new FuncionesRolDTO { Valor = fi.GetValue(null).ToString(), Tipo = "Permiso" });
        }
    }

    public static async Task AgregarClaimPermiso(this RoleManager<IdentityRole> roleManager, IdentityRole role,
        string permission)
    {
        var allClaims = await roleManager.GetClaimsAsync(role);
        if (!allClaims.Any(a => a.Type == "Permiso" && a.Value == permission))
        {
            await roleManager.AddClaimAsync(role, new Claim("Permiso", permission));
        }
    }
}