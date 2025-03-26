using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Tipos;
using AgroConecta.Shared.DTO.Tipos;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema.Tipo;

public class TipoSueloAgent : InitialAgent<TipoSueloDTO>, ITipoSueloAgent
{
    public TipoSueloAgent(HttpClient httpClient, IJSRuntime jsRuntime) 
        : base(httpClient, "api/TiposSuelo", jsRuntime) // Ruta del controlador
    {
    }

    // // Método específico (devuelve DTOs, no entidades)
    // public async Task<IEnumerable<TerrenoDTO>> GetTerrenosByUbicacionAsync(string ubicacion)
    // {
    //     return await _httpClient.GetFromJsonAsync<IEnumerable<TerrenoDTO>>($"{_endpoint}/ubicacion/{ubicacion}") 
    //            ?? Enumerable.Empty<TerrenoDTO>();
    // }
}