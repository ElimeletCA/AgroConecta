using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Components.Forms;

namespace AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.General;


public interface IArchivoAgent : IInitialAgent<ArchivoDTO>
{
    Task<bool> UploadFiles(List<IBrowserFile> archivos, string entityId);
    Task<IEnumerable<ArchivoDTO>> GetFilesOfEntity(string entityId);
}