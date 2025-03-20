using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Tipos;
using AgroConecta.Shared.DTO.Tipos;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema.Tipo;

public class TipoArrendamientoAgent : InitialAgent<TipoArrendamientoDTO>, ITipoArrendamientoAgent
{
    public TipoArrendamientoAgent(HttpClient httpClient, IJSRuntime jsRuntime) 
        : base(httpClient, "api/TiposArrendamiento", jsRuntime) // Ruta del controlador
    {
    }

    // // Método específico (devuelve DTOs, no entidades)
    // public async Task<IEnumerable<TerrenoDTO>> GetTerrenosByUbicacionAsync(string ubicacion)
    // {
    //     return await _httpClient.GetFromJsonAsync<IEnumerable<TerrenoDTO>>($"{_endpoint}/ubicacion/{ubicacion}") 
    //            ?? Enumerable.Empty<TerrenoDTO>();
    // }
}