using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Presentation.Seguridad;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<Usuario> _signInManager;

        public AuthController(IAuthService authservice, UserManager<Usuario> userManager, IConfiguration config, SignInManager<Usuario> signInManager )
        {
            _authService = authservice;
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(Usuario usuario)
        {
            try
            {
                if
                (
                    usuario.UserName is null
                    || usuario.pasword_without_hash is null
                    || usuario.nombre_completo is null
                    || usuario.Email is null
                    || usuario.PhoneNumber is null
                )
                {
                    return BadRequest(new{ success = false, message = "ERROR-101" });
                }
                if (!Regex.IsMatch(usuario.UserName, @"^[a-zA-Z]{1,15}$", RegexOptions.IgnoreCase))
                {
                    return BadRequest(new { success = false, message = "ERROR-102" });
                }
                if (!Regex.IsMatch(usuario.pasword_without_hash, @"^.{1,25}$", RegexOptions.IgnoreCase))
                {
                    return BadRequest(new{ success = false, message = "ERROR-103" });
                }
                if (!Regex.IsMatch(usuario.nombre_completo, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜ ]{1,50}$", RegexOptions.IgnoreCase))
                {
                    return BadRequest(new{ success = false, message = "ERROR-104" });
                }
                // linux @"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}:\d{2}$"
                // windows @"^\d{1,2}/\d{1,2}/\d{4} \d{1,2}:\d{2}:\d{2} (AM|PM)$"
                if (!Regex.IsMatch(usuario.fecha_nacimiento.ToString(), @"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}:\d{2}$", RegexOptions.IgnoreCase))
                {
                    return BadRequest(new{ success = false, message = $"{usuario.fecha_nacimiento.ToString()} ERROR-105" });
                }
                if (!Regex.IsMatch(usuario.PhoneNumber, @"^\(\d{3}\) \d{3}-\d{4}$", RegexOptions.IgnoreCase))
                {
                    return BadRequest(new{ success = false, message = "ERROR-106" });
                }
                if (!Regex.IsMatch(usuario.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.IgnoreCase))
                {
                    return BadRequest(new{ success = false, message = "ERROR-107" });
                }
                if (!(await _userManager.FindByNameAsync(usuario.UserName) is null))
                {
                    return BadRequest(new{ success = false, message = "Ya existe una cuenta con ese nombre de usuario, favor verificar e intentar de nuevo" });

                }
                if (!(await _userManager.FindByEmailAsync(usuario.Email) is null))
                {
                    return BadRequest(new { success = false, message = "Ya existe una cuenta con ese correo electrónico, favor verificar e intentar de nuevo" });

                }
                if (await _authService.RegistrarUsuario(usuario))
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                    var confirmationLink = Url.Action("ConfirmarCorreo", "Email", new { token, email = usuario.Email }, Request.Scheme);
                    EmailHelper emailHelper = new EmailHelper(_config);
                    bool emailResponse = emailHelper.EnviarCorreo(usuario.Email, confirmationLink);

                    if (emailResponse)
                    {
                        return BadRequest(new { success = true , message = "Correo de confirmación enviado"});
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "ERROR-108" });
                    }


                }
                return BadRequest(new { success = false, message = "ERROR-109" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex });
            }

        }
        [HttpPost("Login")]
        public async Task<IActionResult>Login([FromBody]UsuarioDTO usuario)
        {
            try {
                var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);

                if (usuarioexistente is null)
                {
                    usuarioexistente = await _userManager.FindByEmailAsync(usuario.Email);
                }

                if (usuarioexistente is null)
                {
                    return Ok(new ApiResponse<BackendMessage>{ success = false, message = BackendMessages.MessageS001 });
                }
                if (!await _userManager.IsEmailConfirmedAsync(usuarioexistente))
                {
                    return  Ok(new ApiResponse<BackendMessage>{ success = false, message = BackendMessages.MessageS002 });
                }

                if (await _authService.LoginUsuario(usuario))
                {
                    bool confirmacionenvio = await EnviarCodigo2FA(usuarioexistente.Email);
                    
                    return  confirmacionenvio
                        ?  Ok(new ApiResponse<BackendMessage>{ success = true, message = BackendMessages.MessageS003 })
                        :  Ok(new ApiResponse<BackendMessage>{  success = false, message = BackendMessages.MessageS004});

                }
                return  Ok(new ApiResponse<BackendMessage>{ success = false, message = BackendMessages.MessageS005 });

            }
            catch( Exception e)
            {
                return StatusCode(500, new { success = false, message=e  });
            }
        }
        private async Task<bool> EnviarCodigo2FA(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) { 
                return false;
            }

            var token = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);
            
            EmailHelper emailHelper = new EmailHelper(_config);
            bool emailResponse = emailHelper.EnviarCorreoCodigoDobleFactor(user.Email, token);
            
            return emailResponse;
        }
        [HttpPost("Verificar2FA")]
        public async Task<IActionResult> Verificar2FA(UsuarioDTO usuario)
        {
            try
            {
                var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);

                if (usuarioexistente is null)
                {
                    usuarioexistente = await _userManager.FindByEmailAsync(usuario.Email);
                }

                if (usuarioexistente is null || usuario.two_factor_code is null)
                {
                    Ok(new { success = false, message = "ERROR" });
                }

                var result = await _userManager.VerifyTwoFactorTokenAsync(usuarioexistente, "Email", usuario.two_factor_code);
                if (result)
                {
                    var token = await _authService.GenerarTokenString(usuarioexistente);
                    return Ok (new  { success = true, message = new BackendMessage(){Codigo = "CODE-JWT", Descripcion = token}});

                }
                return Ok(new { success = false, message = "ERROR" });

            }
            catch( Exception e)
            {
                return StatusCode(500, new { success = false, message=e  });
            }

        }
        [HttpGet("GetTerrenos"), Authorize]
        [RequierePermiso(Permisos.Terrenos.Ver)]
        public async Task<IActionResult> GetTerrenos()
        {
            // Lógica para obtener terrenos...
            return Ok (new  { success = true, message = new BackendMessage(){Codigo = "CODE-AUTHORIZE", Descripcion = "Acceso permitido para ver terrenos"}});

        }

    }