using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgroConecta.Presentation.Controllers.Seguridad;


    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<Usuario> _signInManager;

        public EmailController(IAuthService authservice, UserManager<Usuario> userManager, IConfiguration config,
            SignInManager<Usuario> signInManager)
        {
            _authService = authservice;
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmarCorreo(string encodedToken, string email)
        {
            var result = await _authService.ConfirmarCorreo(encodedToken, email);
            if (result)
            {
                return Redirect("/Seguridad/CorreoConfirmado");

            }
            return Redirect("/Error");
        }
    }

    