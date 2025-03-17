using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema;
using AgroConecta.Shared.DTO;

namespace AgroConecta.Presentation.Client.Agents.Sistema;

public class TipoMedidaAreaAgent : InitialAgent<TipoMedidaAreaDTO>, ITipoMedidaAreaAgent
{
    public TipoMedidaAreaAgent(HttpClient httpClient) 
        : base(httpClient, "api/TiposMedidaArea") // Ruta del controlador
    {
    }

    // // Método específico (devuelve DTOs, no entidades)
    // public async Task<IEnumerable<TerrenoDTO>> GetTerrenosByUbicacionAsync(string ubicacion)
    // {
    //     return await _httpClient.GetFromJsonAsync<IEnumerable<TerrenoDTO>>($"{_endpoint}/ubicacion/{ubicacion}") 
    //            ?? Enumerable.Empty<TerrenoDTO>();
    // }
}