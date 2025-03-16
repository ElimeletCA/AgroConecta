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
public class RolesController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly RoleManager<IdentityRole> _rolManager;

    private readonly UserManager<Usuario> _userManager;
    private readonly IConfiguration _config;
    private readonly SignInManager<Usuario> _signInManager;
    
    public RolesController(
        UserManager<Usuario> userManager,
        IConfiguration config, 
        SignInManager<Usuario> signInManager,
        IUsuarioService usuarioService, RoleManager<IdentityRole> rolManager)
    {
        _userManager = userManager;
        _config = config;
        _signInManager = signInManager;
        _usuarioService = usuarioService;
        _rolManager = rolManager;
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var listaRoles= await _usuarioService.GetAllRolesAsync();

            return Ok(new ApiResponse<IEnumerable<RolDTO>> { success = true, message = listaRoles });

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] RolDTO rol)
    {
        var added = await _usuarioService.AddRoleAsync(rol.Name);
        return Ok(new ApiResponse<bool> { success = added, message = added });
    }
    
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] string rolId)
    {
        var eliminado = await _usuarioService.DeleteRoleAsync(rolId);
        
        return Ok(new ApiResponse<bool> { success = eliminado, message = eliminado });
        
    }
}