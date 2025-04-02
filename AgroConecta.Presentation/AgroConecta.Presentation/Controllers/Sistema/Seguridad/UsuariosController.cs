using System.Text.RegularExpressions;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Presentation.Seguridad;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.DTO.Seguridad;
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
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    private readonly UserManager<Usuario> _userManager;
    private readonly IConfiguration _config;
    private readonly SignInManager<Usuario> _signInManager;
    
    public UsuariosController(
        UserManager<Usuario> userManager,
        IConfiguration config, 
        SignInManager<Usuario> signInManager,
        IUsuarioService usuarioService)
    {
        _userManager = userManager;
        _config = config;
        _signInManager = signInManager;
        _usuarioService = usuarioService;

    }
    
    [HttpGet("GetAllExcept")]
    public async Task<IActionResult> GetAllExcept(string email)
    {
        var currentUser = await _userManager.FindByEmailAsync(email);
        if (currentUser == null || String.IsNullOrEmpty(currentUser.Email))
        {
            return Ok(new ApiResponse<IEnumerable<UsuarioDTO>> { Success = true, Message = new List<UsuarioDTO>() });
        }
        
        var listaUsuarios = await _usuarioService.GetAllExceptAsync(currentUser.Email);
        
        return Ok(new ApiResponse<IEnumerable<UsuarioDTO>> { Success = true, Message = listaUsuarios });

    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string userId)
    {
        var currentUser = await _usuarioService.GetByIdAsync(userId);
        return Ok(new ApiResponse<UsuarioDTO> { Success = true, Message = currentUser });
        
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] string userId)
    {
        var eliminado = await _usuarioService.DeleteAsync(userId);
        
        return Ok(new ApiResponse<bool> { Success = eliminado, Message = eliminado });
        
    }
}