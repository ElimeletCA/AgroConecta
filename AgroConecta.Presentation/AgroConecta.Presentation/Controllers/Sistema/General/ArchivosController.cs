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
    public async Task<ActionResult<List<ArchivoDTO>>> UploadFile(List<IFormFile> files, [FromQuery] string entityId)
    {
        var fullActionName = GetFullActionName();


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
                archivo.EntidadId = entityId;
                uploadResults.Add(archivo);
                await base.Create(archivo);
                


            }
            //Registro de información
            await _logger.LogInformation(
                action: fullActionName,
                message: $"Tipo: {typeof(ArchivoDTO).Name}, Agregado de archivos {files.Count()} registros",
                userEmail: GetCurrentUserEmail(),
                parameters: null
            );
            var response = new ApiResponse<IEnumerable<ArchivoDTO>>
            {
                Success = true,
                Message = uploadResults
            };
            return Ok(response);
            
        }
        catch (Exception ex)
        {
            //Registro de error
            await _logger.LogError(
                action: fullActionName,
                ex: new Exception($"Tipo: {typeof(ArchivoDTO).Name}, Excepción al agregar registro-{ex.Message.Truncate(250)}", new Exception(ex.StackTrace?.Truncate(250))),
                parameters: entityId, 
                userEmail: GetCurrentUserEmail()
            );
            var responseFailed = new ApiResponse<string>
            {
                Success = false,
                Message = "Error interno del servidor. Consulte los logs para más detalles."
            };
            return StatusCode(500, responseFailed);
        }

    }
    
}
