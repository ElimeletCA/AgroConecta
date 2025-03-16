using System.Collections;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AgroConecta.Application.Servicios.Sistema.Seguridad;

public class UsuarioService : IUsuarioService
{
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _rolManager;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    
    public UsuarioService
    (
        UserManager<Usuario> userManager,
        RoleManager<IdentityRole> rolManager,
        IConfiguration config,
        IMapper mapper
    )
    {
        _userManager = userManager;
        _rolManager = rolManager;
        _config = config;
        _mapper = mapper;

    }
    /// <summary>
    /// Retorna todos los usuarios, excepto el usuario del correo suministrado
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<IEnumerable<UsuarioDTO>> GetAllExceptAsync(string email)
    {
        var currentUser = await _userManager.FindByEmailAsync(email);
        
        if (currentUser == null)
        {
            return new List<UsuarioDTO>();
        }
        
        var allUsersExceptCurrentUser = 
            await _userManager.Users.Where(a => a.Id != currentUser.Id).ToListAsync();
        
        var listaUsuario = _mapper.Map<IEnumerable<UsuarioDTO>>(allUsersExceptCurrentUser);
        
        return listaUsuario;
    }
    public async Task<UsuarioDTO> GetByIdAsync(string id)
    {
        var currentUser = await _userManager.FindByIdAsync(id);
        if (currentUser == null || String.IsNullOrEmpty(currentUser.Email))
        {
            return new UsuarioDTO();
        }
        return _mapper.Map<UsuarioDTO>(currentUser);
        
        
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var user = _userManager.FindByIdAsync(id).Result;
        if (user != null)
        {
            var eliminado = await _userManager.DeleteAsync(user);
            return eliminado.Succeeded;

        }
        return false;
    }
    
    public async Task<IEnumerable<RolDTO>> GetAllRolesAsync()
    {
        var listaRoles = await _rolManager.Roles.Where(x => x.Name != Roles.Administrador.ToString()).ToListAsync();
        var listaRolesDto = _mapper.Map<IEnumerable<RolDTO>>(listaRoles);
        return listaRolesDto;
    }
    public async Task<bool> AddRoleAsync(string rolName)
    {
        if (!String.IsNullOrEmpty(rolName))
        {
            var result = await _rolManager.CreateAsync(new IdentityRole(rolName.Trim()));
            return result.Succeeded;
        }

        return false;
    }
    public async Task<bool> DeleteRoleAsync(string rolId)
    {
        if (!String.IsNullOrEmpty(rolId))
        {
            var rol = _rolManager.FindByIdAsync(rolId).Result;
            if (rol != null)
            {
                var eliminado = await _rolManager.DeleteAsync(rol);
                return eliminado.Succeeded;
            }
        }

        return false;
    }
    
    public async Task<PermisoDTO> GetALlPermisosByRolId(string rolId)
    {
        var model = new PermisoDTO();
        var allPermiso = new List<FuncionesRolDTO>();

        // Obtén todos los tipos de permisos automáticamente
        var permisoTypes = typeof(Permisos).GetNestedTypes(BindingFlags.Static | BindingFlags.Public);
        foreach (var permisoType in permisoTypes)
        {
            allPermiso.ObtenerPermisos(permisoType, rolId);
        }

        var role = await _rolManager.FindByIdAsync(rolId);
        model.RolId = role.Id;
        model.NombreRol = role.Name;

        var claims = await _rolManager.GetClaimsAsync(role);

        var allClaimValues = allPermiso.Select(a => a.Valor).ToList();
        var roleClaimValues = claims.Select(a => a.Value).ToList();
        var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();

        foreach (var permission in allPermiso)
        {
            if (authorizedClaims.Any(a => a == permission.Valor))
            {
                permission.Asignada = true;
            }
        }

        model.FuncionesRol = allPermiso;
        
        return model;
    }

    public async Task<bool> UpdatePermisos(PermisoDTO permisosRol)
    {
        var role = await _rolManager.FindByIdAsync(permisosRol.RolId);
        var claims = await _rolManager.GetClaimsAsync(role);
        foreach (var claim in claims)
        {
            await _rolManager.RemoveClaimAsync(role, claim);
        }
        var selectedClaims = permisosRol.FuncionesRol.Where(a => a.Asignada).ToList();
        foreach (var claim in selectedClaims)
        {
            await _rolManager.AgregarClaimPermiso(role, claim.Valor);
        }
        return true;
    }

}