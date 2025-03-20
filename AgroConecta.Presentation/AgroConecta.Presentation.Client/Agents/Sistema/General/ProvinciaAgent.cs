using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.General;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.DTO.Tipos;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema.General;

public class ProvinciaAgent : InitialAgent<ProvinciaDTO>, IProvinciaAgent
{
    public ProvinciaAgent(HttpClient httpClient, IJSRuntime jsRuntime) 
        : base(httpClient, "api/Provincias", jsRuntime) // Ruta del controlador
    {
    }

    // // Método específico (devuelve DTOs, no entidades)
    // public async Task<IEnumerable<TerrenoDTO>> GetTerrenosByUbicacionAsync(string ubicacion)
    // {
    //     return await _httpClient.GetFromJsonAsync<IEnumerable<TerrenoDTO>>($"{_endpoint}/ubicacion/{ubicacion}") 
    //            ?? Enumerable.Empty<TerrenoDTO>();
    // }
}