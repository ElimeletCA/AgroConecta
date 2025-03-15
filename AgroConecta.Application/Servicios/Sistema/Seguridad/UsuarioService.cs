using System.Collections;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
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
}