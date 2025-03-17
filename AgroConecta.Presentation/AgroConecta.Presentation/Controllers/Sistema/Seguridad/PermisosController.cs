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
public class PermisosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;
    private readonly SignInManager<Usuario> _signInManager;
    
    public PermisosController(
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
    
    [HttpGet("GetALlPermisosByRolId")]
    public async Task<IActionResult> GetALlPermisosByRolId([FromQuery] string rolId)
    {
        var permisosRol = await _usuarioService.GetALlPermisosByRolId(rolId);

        return Ok(new ApiResponse<PermisoDTO> { Success = true, Message = permisosRol });
    }
    
    [HttpPut("UpdatePermisos")]
    public async Task<IActionResult> UpdatePermisos([FromBody] PermisoDTO permisosRol)
    {
        var actualizado = await _usuarioService.UpdatePermisos(permisosRol);

        return Ok(new ApiResponse<bool> { Success = actualizado, Message = actualizado });
    }
}