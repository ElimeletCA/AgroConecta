using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema;
using AgroConecta.Domain.Sistema;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AgroConecta.Presentation.Controllers.Sistema;

[Authorize]
[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Administrador")]
public class TerrenosController : InitialController<TerrenoDTO, Terreno>
{
    public TerrenosController(ITerrenoService service, ILogService logger, IActionContextAccessor actionContextAccessor)
        : base(service, logger, actionContextAccessor )
    {
    }

}
