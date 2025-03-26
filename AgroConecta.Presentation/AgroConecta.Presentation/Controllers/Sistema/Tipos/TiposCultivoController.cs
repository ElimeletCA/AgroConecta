using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.Tipos;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Shared.DTO.Tipos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AgroConecta.Presentation.Controllers.Sistema.Tipos;

[Authorize]
[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Administrador")]
public class TiposCultivoController : InitialController<TipoCultivoDTO, TipoCultivo>
{
    public TiposCultivoController(ITipoCultivoService service, ILogService logger, IActionContextAccessor actionContextAccessor)
        : base(service, logger, actionContextAccessor )
    {
    }


}

