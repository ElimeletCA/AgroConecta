using AgroConecta.Application.Servicios.Interfaces.Sistema;
using AgroConecta.Domain.Sistema;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroConecta.Presentation.Controllers.Sistema;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Administrador")]
public class TerrenosController : InitialController<TerrenoDTO, Terreno>
{
    public TerrenosController(ITerrenoService service)
        : base(service)
    {
    }

}
