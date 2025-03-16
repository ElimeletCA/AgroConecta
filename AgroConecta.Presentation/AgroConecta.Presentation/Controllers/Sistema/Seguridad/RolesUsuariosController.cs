using System.Text.RegularExpressions;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Presentation.Seguridad;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroConecta.Presentation.Controllers.Sistema.Seguridad;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Administrador")]
public class RolesUsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;
    private readonly SignInManager<Usuario> _signInManager;
    
    public RolesUsuariosController(
        UserManager<Usuario> userManager,
        IConfiguration config, 
        SignInManager<Usuario> signInManager,
        IUsuarioService usuarioService, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _config = config;
        _signInManager = signInManager;
        _usuarioService = usuarioService;
        _roleManager = roleManager;
    }
    
    [HttpGet("GetAllRolesById")]
    public async Task<IActionResult> GetAllRolesById(string userId)
    {
        var listaRolesUsuario = new List<RolUsuarioDTO>();
        var user = await _userManager.FindByIdAsync(userId);
        foreach (var role in _roleManager.Roles.ToList())
        {
            var rolUsuario = new RolUsuarioDTO
            {
                NombreRol = role.Name
            };
            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                rolUsuario.Asignado = true;
            }
            else
            {
                rolUsuario.Asignado = false;
            }
            listaRolesUsuario.Add(rolUsuario);
        }
        var model = new AdministrarRolesUsuarioDTO()
        {
            UsuarioId = userId,
            RolesUsuario = listaRolesUsuario
        };
        return Ok(new ApiResponse<AdministrarRolesUsuarioDTO> { success = true, message = model });
    }
    
    [HttpPut("UpdateRolesById")]
    public async Task<IActionResult> UpdateRolesById
    (
        [FromQuery] string userId,
        [FromBody] AdministrarRolesUsuarioDTO model
    )
    {
        var user = await _userManager.FindByIdAsync(userId);
        var roles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, roles);
        
        result = await _userManager.AddToRolesAsync(user, model.RolesUsuario
            .Where(x => x.Asignado)
            .Select(y => y.NombreRol));
        
        var currentUser = await _userManager.GetUserAsync(User);
        await _signInManager.RefreshSignInAsync(currentUser);
        //await Seeds.DefaultUsers.SembrarUsuarioAdministradorAsync(_userManager, _roleManager, _configuration["DefaultUser:Password"]);
        return Ok(new ApiResponse<string> { success = true, message = userId });
    }
}