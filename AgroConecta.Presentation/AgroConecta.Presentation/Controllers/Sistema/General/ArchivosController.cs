using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.General;
using AgroConecta.Domain.Sistema.Extras;
using AgroConecta.Domain.Sistema.General;
using AgroConecta.Shared.Constantes.Seguridad;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Extensions;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AgroConecta.Presentation.Controllers.Sistema.General;

[Authorize]
[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Administrador")]
public class ArchivosController : InitialController<ArchivoDTO, Archivo>
{
    public ArchivosController(IWebHostEnvironment env, IArchivoService service, ILogService logger, IActionContextAccessor actionContextAccessor)
        : base(service, logger, actionContextAccessor )
    {
        _env = env;

    }

    private readonly IWebHostEnvironment _env;
    [HttpPost]
    public async Task<ActionResult<List<ArchivoDTO>>> UploadFile(List<IFormFile> files)
    {

        try
        {
            List<ArchivoDTO> uploadResults = new List<ArchivoDTO>();
 
            foreach(var file in files)
            {
                var archivo = new ArchivoDTO();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                archivo.NombreArchivo = untrustedFileName;
                //var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);
 
                trustedFileNameForFileStorage = file.FileName;
                var uploadsPath = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }
                var path = Path.Combine(uploadsPath, trustedFileNameForFileStorage); 
                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);
                //archivo.NombreArchivo = "Hola";
                archivo.NombreArchivoAlmacenado = trustedFileNameForFileStorage;
                archivo.TipoContenido = file.ContentType;
                archivo.TipoArchivoId = TiposArchivos.ImagenId;
                uploadResults.Add(archivo);
                await base.Create(archivo);

            }
            return Ok(uploadResults);
        }
        catch (Exception ex)
        {
            var responseFailed = new ApiResponse<string>
            {
                Success = false,
                Message = "Error interno del servidor. Consulte los logs para más detalles."
            };
            return StatusCode(500, responseFailed);
        }

    }
    
}
