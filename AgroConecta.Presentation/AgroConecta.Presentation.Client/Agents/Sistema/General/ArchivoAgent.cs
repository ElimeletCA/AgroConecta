using System.Collections;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.General;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.DTO.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema.General;


public class ArchivoAgent : InitialAgent<ArchivoDTO>, IArchivoAgent
{
    public ArchivoAgent(HttpClient httpClient, IJSRuntime jsRuntime) 
        : base(httpClient, "api/Archivos", jsRuntime) // Ruta del controlador
    {
    }

    public async Task<bool> UploadFiles( List<IBrowserFile> archivos, string entityId)
    {
        try
        {
            // Crear el contenido multipart/form-data
            var content = new MultipartFormDataContent();
            foreach (var file in archivos)
            {
                var sanitizedFileName = SanitizeFileName(file.Name);

                // Limitar el tamaño de lectura si es necesario (ej. 25MB por archivo)
                var stream = file.OpenReadStream(25 * 1024 * 1024);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                // El nombre "files" debe coincidir con el parámetro de la API
                content.Add(streamContent, "files", sanitizedFileName);
            }

            // Realizar la petición POST al endpoint
            var response = await _httpClient.PostAsync($"{_endpoint}?entityId={entityId}", content);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    public async Task<IEnumerable<ArchivoDTO>> GetFilesOfEntity(string entityId)
    {
        var archivos = await base.GetAllAsync(); 
        var archivosResultado = archivos
            .Where(x => x.EntidadId == entityId);
        
        return archivosResultado;

    }

    private string SanitizeFileName(string fileName)
    {
        // Separa el nombre y la extensión
        var nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        var extension = Path.GetExtension(fileName);
    
        // Elimina todos los caracteres que no sean letras o números
        var sanitized = Regex.Replace(nameWithoutExtension, "[^a-zA-Z0-9]", "");
    
        // Trunca el nombre a un máximo de 25 caracteres
        if (sanitized.Length > 25)
        {
            sanitized = sanitized.Substring(0, 25);
        }
    
        // Devuelve el nombre sanitizado con la extensión original
        return sanitized + extension;
    }
}