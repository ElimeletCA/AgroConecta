using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.General;
using AgroConecta.Shared.DTO;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema.General;


public class ArchivoAgent : InitialAgent<ArchivoDTO>, IArchivoAgent
{
    public ArchivoAgent(HttpClient httpClient, IJSRuntime jsRuntime) 
        : base(httpClient, "api/Archivos", jsRuntime) // Ruta del controlador
    {
    }

    // // Método específico (devuelve DTOs, no entidades)
    // public async Task<IEnumerable<TerrenoDTO>> GetTerrenosByUbicacionAsync(string ubicacion)
    // {
    //     return await _httpClient.GetFromJsonAsync<IEnumerable<TerrenoDTO>>($"{_endpoint}/ubicacion/{ubicacion}") 
    //            ?? Enumerable.Empty<TerrenoDTO>();
    // }
}