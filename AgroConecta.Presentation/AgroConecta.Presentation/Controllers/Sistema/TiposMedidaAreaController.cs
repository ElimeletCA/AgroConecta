using AgroConecta.Application.Servicios.Interfaces.Sistema;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AgroConecta.Presentation.Controllers.Sistema;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Administrador")]
public class TiposMedidaAreaController : InitialController<TipoMedidaAreaDTO, TipoMedidaArea>
{
    public TiposMedidaAreaController(ITipoMedidaAreaService service)
        : base(service)
    {
    }

}