using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Tipos;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.DTO.Tipos;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema;

public class TerrenoAgent : InitialAgent<TerrenoDTO>, ITerrenoAgent
{
    public TerrenoAgent(HttpClient httpClient, IJSRuntime jsRuntime) 
        : base(httpClient, "api/Terrenos", jsRuntime) // Ruta del controlador
    {
    }

    // // Método específico (devuelve DTOs, no entidades)
    // public async Task<IEnumerable<TerrenoDTO>> GetTerrenosByUbicacionAsync(string ubicacion)
    // {
    //     return await _httpClient.GetFromJsonAsync<IEnumerable<TerrenoDTO>>($"{_endpoint}/ubicacion/{ubicacion}") 
    //            ?? Enumerable.Empty<TerrenoDTO>();
    // }
}