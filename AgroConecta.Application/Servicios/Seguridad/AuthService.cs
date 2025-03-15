using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.Seguridad;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;

namespace AgroConecta.Application.Servicios.Seguridad;

public class AuthService : IAuthService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _rolManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService
        (
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Usuario> userManager,
            RoleManager<IdentityRole> rolManager,
            IConfiguration config,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _rolManager = rolManager;
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _mapper = mapper;

        }

        public async Task<bool> RegistrarUsuario(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var result = await _userManager.CreateAsync(usuario, usuario.pasword_without_hash);
            return result.Succeeded;
        }

        public async Task<bool> GenerarCorreoDeConfirmacion(UsuarioDTO usuarioDto)
        {
            //var usuarioEn = _mapper.Map<Usuario>(usuarioDto);
            var usuario = await _userManager.FindByEmailAsync(usuarioDto.Email);
            
            if (usuario == null)
                return false;
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            
            
            var httpContext = _httpContextAccessor.HttpContext;
            var scheme = httpContext?.Request.Scheme ?? "https";
            var confirmationLink = _linkGenerator.GetUriByAction(
                httpContext, 
                action: "ConfirmarCorreo", 
                controller: "Email", 
                values: new { encodedToken, email = usuario.Email }, 
                scheme: scheme);
            
            EmailHelper emailHelper = new EmailHelper(_config);
            return emailHelper.EnviarCorreo(usuario.Email, confirmationLink);
        }
        public async Task<bool> ConfirmarCorreo(string token, string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario == null)
                return false;
            
            var decodedToken = Encoding.UTF8.GetString( WebEncoders.Base64UrlDecode(token));
            
            var result = await _userManager.ConfirmEmailAsync(usuario, decodedToken);
             if (result.Succeeded)
             {
                 var result2fa = _userManager.SetTwoFactorEnabledAsync(usuario, true);
             }

            return result.Succeeded;
        }


        public async Task<bool> LoginUsuario(UsuarioDTO usuario)
        {
            try
            {
                var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);

                if (usuarioexistente is null)
                {
                    usuarioexistente = await _userManager.FindByEmailAsync(usuario.Email);
                }

                if (usuarioexistente is null)
                {
                    return false;
                }
                return await _userManager.CheckPasswordAsync(usuarioexistente, usuario.pasword_without_hash);
            } catch {
                return false;

            }

        }

        public async Task<string> GenerarTokenString(Usuario usuario)
        {
            var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuarioexistente.Id),
                new Claim(JwtRegisteredClaimNames.Name, usuarioexistente.UserName),
                //new Claim(ClaimTypes.Role, "Admin")
            };


            var roles = await _userManager.GetRolesAsync(usuarioexistente);
            claims.AddRange(roles.Select(rol => new Claim(ClaimTypes.Role, rol)));

            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                var roleEntity = await _rolManager.FindByNameAsync(role);
                if (roleEntity != null)
                {
                    var claimsFromRole = await _rolManager.GetClaimsAsync(roleEntity);
                    roleClaims.AddRange(claimsFromRole.Where(claim => claim.Type == "Permiso"));
                }
            }
            claims.AddRange(roleClaims);

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signingcred = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: System.DateTime.Now.AddMinutes(10),
                signingCredentials: signingcred);
                
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
        public void ColocarJwtTokenEnCookie(string token, HttpContext context)
        {
            try
            {
                context.Response.Cookies.Append("tokenacceso", token,
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddMinutes(10),
                        HttpOnly = true,
                        IsEssential = true,
                        Secure = true,
                        SameSite = SameSiteMode.None
                    });
            }
            catch {

            }

        }
        public bool ExisteTokenValido(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("tokenacceso", out var token) && !string.IsNullOrEmpty(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

                try
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _config["Jwt:Issuer"],
                        ValidAudience = _config["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    }, out SecurityToken validatedToken);

                    return true; // Token is valid
                }
                catch
                {
                    return false; // Token is invalid
                }
            }
            return false; // No token found
        }
        public void EliminarJwtTokenDeCookie(HttpContext context)
        {
            context.Response.Cookies.Delete("tokenacceso");
        }
    }