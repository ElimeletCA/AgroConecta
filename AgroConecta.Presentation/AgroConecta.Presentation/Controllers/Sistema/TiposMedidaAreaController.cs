using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AgroConecta.Presentation.Controllers.Sistema;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Administrador")]
public class TiposMedidaAreaController : InitialController<TipoMedidaAreaDTO, TipoMedidaArea>
{
    public TiposMedidaAreaController(ITipoMedidaAreaService service, ILogService logger, IActionContextAccessor actionContextAccessor)
        : base(service, logger, actionContextAccessor )
    {
    }


}

