using AgroConecta.Application.Servicios.Interfaces.Sistema;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad.Mensajes;
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

    [HttpPost]
    public override Task<IActionResult> Create(TipoMedidaAreaDTO dto)
    {
        
        return base.Create(dto);
    }
    [HttpPut]

    public override Task<ActionResult<ApiResponse<TipoMedidaAreaDTO>>> Update(string id, TipoMedidaAreaDTO dto)
    {
        return base.Update(id, dto);
    }
}

