using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.System.Seguridad;
using AgroConecta.Shared.Security;

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
        /*[HttpPost]
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

        }*/
        /*[HttpPost("Login")]
        public async Task<IActionResult>Login([FromBody]UsuarioDTO usuario)
        {
            try {
                var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);

                if (usuarioexistente is null)
                {
                    usuarioexistente = await _userManager.FindByEmailAsync(usuario.UserName);
                }

                if (usuarioexistente is null)
                {
                    return BadRequest(new  { success = false, message = "No existe el usuario en nuestro sistema, por favor verifique los datos e intente de nuevo." });
                }
                if (!await _userManager.IsEmailConfirmedAsync(usuarioexistente))
                {
                    return BadRequest(new  { success = false, message = "El correo electrónico del usuario aún no ha sido verificado, realice la verificación o contacte a soporte técnico" });
                }

                if (await _authService.LoginUsuario(usuario))
                {
                    bool confirmacionenvio = await EnviarCodigo2FA(usuarioexistente.Email);
                    
                    return  confirmacionenvio? Ok(new { success = confirmacionenvio, message = "2FA" }): BadRequest(new { success = confirmacionenvio, message = "2FA" });

                }
                else
                {
                    return BadRequest(new  { success = false, message = "Usuario o contraseña incorrectos, por favor verifique los datos e intente de nuevo." });

                }
            } catch
            {
                return BadRequest(new  { success = false, message = "ERROR" });
            }

        }*/
        [HttpPost("Login")]
        public async Task<ActionResult<string>> InicioSesion(UsuarioDTO objeto)
        {
            var cvc = "df";
            // var cuanta = await _context.Usuarios.Where(x => x.Email == objeto.Email).FirstOrDefaultAsync();
            // if (cuanta == null)
            // {
            //     return BadRequest("Usuario no encontrado");
            // }
            // if (!VerifyPasswordHash(objeto.Password, cuanta.PasswordHash, cuanta.PasswordSalt))
            // {
            //     return BadRequest("Contraseña incorrecta");
            // }
            // string token = CreateToken(cuanta);
            return Ok("token");

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
        /*[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Verificar2FA(UsuarioDTO usuario)
        {
            try
            {
                var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);

                if (usuarioexistente is null)
                {
                    usuarioexistente = await _userManager.FindByEmailAsync(usuario.UserName);
                }

                if (usuarioexistente is null || usuario.two_factor_code is null)
                {
                    return BadRequest(new  { success = false, message = "ERROR" });
                }

                var result = await _userManager.VerifyTwoFactorTokenAsync(usuarioexistente, "Email", usuario.two_factor_code);
                if (result)
                {
                    var token = await _authService.GenerarTokenString(usuarioexistente);
                    //_authService.ColocarJwtTokenEnCookie(token , HttpContext);
                    return Ok (new  { success = true, message = "VERIFICADO" , token_generado = token});

                }
                else
                {
                    return BadRequest(new  { success = false, message = "ERROR" });

                }
            }
            catch(Exception ex)
            {
                return BadRequest(new  { success = false, message = ex });
            }

        }*/

        // [HttpPost]
        // public async Task<IActionResult> CerrarSesion()
        // {
        //     _authService.EliminarJwtTokenDeCookie(HttpContext);
        //     return Ok (new  { success = true });
        // }

    }