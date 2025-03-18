using System.Text.RegularExpressions;
using AgroConecta.Application.Helpers;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Presentation.Seguridad;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.Extensions;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AgroConecta.Presentation.Controllers.Seguridad;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ILogService _logger;
        protected string GetFullActionName()
        {
            var routeData = ControllerContext.RouteData;
            var controllerName = routeData.Values["controller"]?.ToString();
            var actionName = routeData.Values["action"]?.ToString();
            return $"{controllerName}/{actionName}";
        }
        public AuthController(IAuthService authservice, UserManager<Usuario> userManager, IConfiguration config, SignInManager<Usuario> signInManager, ILogService logger)
        {
            _authService = authservice;
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
            _logger = logger;
        }
        [HttpPost("Registro")]
        public async Task<IActionResult>Registro([FromBody]UsuarioDTO usuario)
        {
            var fullActionName = GetFullActionName();

            try
            {
                if
                (
                    usuario.UserName is null
                    || usuario.pasword_without_hash is null
                    || usuario.Email is null
                )
                {
                    usuario.pasword_without_hash = string.Empty;
                    //Registro de información
                    await _logger.LogWarning(
                        action: fullActionName,
                        message: $"Tipo: {typeof(UsuarioDTO).Name}, Fallo al intentar registrar usuario UserName is null || usuario.pasword_without_hash is null || usuario.Email is null",
                        userEmail: usuario.Email ?? string.Empty,
                        parameters:usuario
                    );
                    return Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS000 });
                }
                
                if (!(await _userManager.FindByNameAsync(usuario.UserName) is null))
                {
                    usuario.pasword_without_hash = string.Empty;

                    //Registro de información
                    await _logger.LogWarning(
                        action: fullActionName,
                        message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo al intentar registrar usuario, Ya existe una cuenta con ese nombre de usuario",
                        userEmail: usuario.Email ?? string.Empty,
                        parameters:usuario
                    );
                    return Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS000 });

                }
                if (!(await _userManager.FindByEmailAsync(usuario.Email) is null))
                {
                    usuario.pasword_without_hash = string.Empty;

                    //Registro de información
                    await _logger.LogWarning(
                        action: fullActionName,
                        message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo al intentar registrar usuario, Ya existe una cuenta con ese correo electrónico",
                        userEmail: usuario.Email ?? string.Empty,
                        parameters:usuario
                    );
                    return Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS000 });

                }
                if (await _authService.RegistrarUsuario(usuario))
                {

                    if (await _authService.GenerarCorreoDeConfirmacion(usuario))
                    {
                        usuario.pasword_without_hash = string.Empty;

                        //Registro de información
                        await _logger.LogInformation(
                            action: fullActionName,
                            message: $"Tipo: {typeof(UsuarioDTO).Name}, Éxito al Generar Correo De Confirmacion",
                            userEmail: usuario.Email ?? string.Empty,
                            parameters: usuario
                        );
                        return Ok(new ApiResponse<BackendMessage>{ Success = true, Message = BackendMessages.MessageS006 });

                    }
                    else
                    {
                        usuario.pasword_without_hash = string.Empty;

                        //Registro de información
                        await _logger.LogWarning(
                            action: fullActionName,
                            message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo al intentar generar correo de confirmación",
                            userEmail: usuario.Email ?? string.Empty,
                            parameters:usuario
                        );
                        return Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS000 });
                    }


                }
                usuario.pasword_without_hash = string.Empty;

                //Registro de información
                await _logger.LogWarning(
                    action: fullActionName,
                    message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo en _authService.RegistrarUsuario",
                    userEmail: usuario.Email ?? string.Empty,
                    parameters:usuario
                );
                return Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS000 });
            }
            catch (Exception ex)
            {
                usuario.pasword_without_hash = string.Empty;

                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(UsuarioDTO).Name}, Excepción al registrar usuario-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    parameters: usuario, 
                    userEmail: usuario.Email ?? string.Empty
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);            }

        }
        
        [HttpPost("Login")]
        public async Task<IActionResult>Login([FromBody]UsuarioDTO usuario)
        {
            var fullActionName = GetFullActionName();

            try {
                var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);

                if (usuarioexistente is null)
                {
                    usuarioexistente = await _userManager.FindByEmailAsync(usuario.Email);
                }

                if (usuarioexistente is null)
                {
                    usuario.pasword_without_hash = string.Empty;

                    //Registro de warning
                    await _logger.LogWarning(
                        action: fullActionName,
                        message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo en login: No existe el usuario en el sistema",
                        userEmail: usuario.Email ?? string.Empty,
                        parameters:usuario
                    );
                    return Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS001 });
                }
                if (!await _userManager.IsEmailConfirmedAsync(usuarioexistente))
                {
                    usuario.pasword_without_hash = string.Empty;

                    //Registro de warning
                    await _logger.LogWarning(
                        action: fullActionName,
                        message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo en login: El correo electrónico del usuario aún no ha sido verificado",
                        userEmail: usuario.Email ?? string.Empty,
                        parameters:usuario
                    );
                    return  Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS002 });
                }

                if (await _authService.LoginUsuario(usuario))
                {
                    
                    var enable2FA = _config["Security:Enable2FA"];
                    if (!String.IsNullOrEmpty(enable2FA))
                    {
                        if (bool.Parse(enable2FA))
                        {
                            bool confirmacionenvio = await EnviarCodigo2FA(usuarioexistente.Email);
                            if (confirmacionenvio)
                            {
                                usuario.pasword_without_hash = string.Empty;

                                //Registro de información
                                await _logger.LogInformation(
                                    action: fullActionName,
                                    message: $"Tipo: {typeof(UsuarioDTO).Name},Exito en login: Se ha enviado un código de autenticación de dos factores (2FA)",
                                    userEmail: usuario.Email ?? string.Empty,
                                    parameters: usuario
                                );
                                Ok(new ApiResponse<BackendMessage>
                                    { Success = true, Message = BackendMessages.MessageS003 });
                            }
                            else
                            {
                                usuario.pasword_without_hash = string.Empty;

                                //Registro de warning
                                await _logger.LogWarning(
                                    action: fullActionName,
                                    message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo en login: Ha ocurrido un error al enviar un código de autenticación de dos factores (2FA)",
                                    userEmail: usuario.Email ?? string.Empty,
                                    parameters:usuario
                                );
                                Ok(new ApiResponse<BackendMessage>{  Success = false, Message = BackendMessages.MessageS004});
                            }
                        }
                        var token = await _authService.GenerarTokenString(usuarioexistente);
                        usuario.pasword_without_hash = string.Empty;

                        //Registro de información
                        await _logger.LogInformation(
                            action: fullActionName,
                            message: $"Tipo: {typeof(UsuarioDTO).Name},Exito en login: Se ha generado token sin pasar por 2FA",
                            userEmail: usuario.Email ?? string.Empty,
                            parameters: usuario
                        );
                        return Ok(new ApiResponse<BackendMessage>
                            { Success = true, Message = new BackendMessage() { Codigo = TipoCodigo.Skip2FA, Descripcion = token} });

                    }


                }
                usuario.pasword_without_hash = string.Empty;

                //Registro de warning
                await _logger.LogWarning(
                    action: fullActionName,
                    message: $"Tipo: {typeof(UsuarioDTO).Name},  Fallo en login: _authService.LoginUsuario(usuario)",
                    userEmail: usuario.Email ?? string.Empty,
                    parameters:usuario
                );
                return  Ok(new ApiResponse<BackendMessage>{ Success = false, Message = BackendMessages.MessageS005 });

            }
            catch( Exception ex)
            {
                usuario.pasword_without_hash = string.Empty;

                //Registro de error
                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(UsuarioDTO).Name}, Excepción al iniciar sesión-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    parameters: usuario, 
                    userEmail: usuario.Email ?? string.Empty
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);                 }
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
            var fullActionName = GetFullActionName();

            try
            {
                var usuarioexistente = await _userManager.FindByNameAsync(usuario.UserName);

                if (usuarioexistente is null)
                {
                    usuarioexistente = await _userManager.FindByEmailAsync(usuario.Email);
                }

                if (usuarioexistente is not null)
                {
                    var enable2FA = _config["Security:Enable2FA"];
                    if (!String.IsNullOrEmpty(enable2FA))
                    {
                        if (bool.Parse(enable2FA))
                        {
                            var result = await _userManager.VerifyTwoFactorTokenAsync(usuarioexistente, "Email", usuario.two_factor_code);
                            if (result)
                            {
                                var token = await _authService.GenerarTokenString(usuarioexistente);
                                usuario.pasword_without_hash = string.Empty;

                                //Registro de información
                                await _logger.LogInformation(
                                    action: fullActionName,
                                    message: $"Tipo: {typeof(UsuarioDTO).Name},Exito en Verificar 2FA: Se ha generado token verificando 2FA",
                                    userEmail: usuario.Email ?? string.Empty,
                                    parameters: usuario
                                );
                                return Ok (new  { success = true, message = new BackendMessage(){Codigo = "CODE-JWT", Descripcion = token}});

                            }
                        }
                        else
                        {
                            //Registro de información
                            usuario.pasword_without_hash = string.Empty;

                            await _logger.LogInformation(
                                action: fullActionName,
                                message: $"Tipo: {typeof(UsuarioDTO).Name},Exito en Verificar 2FA: Se ha generado token sin pasar por 2FA",
                                userEmail: usuario.Email ?? string.Empty,
                                parameters: usuario
                            );
                            var token = await _authService.GenerarTokenString(usuarioexistente);
                            return Ok (new  { success = true, message = new BackendMessage(){Codigo = "CODE-JWT", Descripcion = token}});

                        }      
                    }
                }
                return Ok(new { success = false, message = "ERROR" });

               

            }
            catch( Exception ex)
            {
                //Registro de error
                usuario.pasword_without_hash = string.Empty;

                await _logger.LogError(
                    action: fullActionName,
                    ex: new Exception($"Tipo: {typeof(UsuarioDTO).Name}, Excepción al Verificar 2FA-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                    parameters: usuario, 
                    userEmail: usuario.Email ?? string.Empty
                );
                var responseFailed = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error interno del servidor. Consulte los logs para más detalles."
                };
                return StatusCode(500, responseFailed);                }

        }
        
        [HttpGet("GetTerrenos"), Authorize]
        [RequierePermiso(Permisos.Terrenos.Ver)]
        public async Task<IActionResult> GetTerrenos()
        {
            // Lógica para obtener terrenos...
            return Ok (new  { success = true, message = new BackendMessage(){Codigo = "CODE-AUTHORIZE", Descripcion = "Acceso permitido para ver terrenos"}});

        }

    }