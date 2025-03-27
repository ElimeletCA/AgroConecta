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

    public new async Task<IEnumerable<TerrenoDTO>> GetAllAsync(string[] includes = null)
    {
        var terrenos = await base.GetAllAsync(includes);
        // Aquí puedes agregar lógica adicional específica para TerrenoDTO si es necesario
        return terrenos;
    }
    public new async Task<TerrenoDTO> GetByIdAsync(string id, string[] includes = null)
    {
        var terreno = await base.GetByIdAsync(id, includes);
        // Aquí puedes agregar lógica adicional específica para TerrenoDTO si es necesario
        return terreno ?? new TerrenoDTO();
    }
    // // Método específico (devuelve DTOs, no entidades)
    // public async Task<IEnumerable<TerrenoDTO>> GetTerrenosByUbicacionAsync(string ubicacion)
    // {
    //     return await _httpClient.GetFromJsonAsync<IEnumerable<TerrenoDTO>>($"{_endpoint}/ubicacion/{ubicacion}") 
    //            ?? Enumerable.Empty<TerrenoDTO>();
    // }
}