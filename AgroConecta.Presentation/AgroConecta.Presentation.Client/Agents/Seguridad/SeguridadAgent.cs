using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces;
using AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;
using AgroConecta.Shared.Seguridad;

namespace AgroConecta.Presentation.Client.Agents.Seguridad;

public class SeguridadAgent : BaseAgent<UsuarioDTO>, ISeguridadAgent
{
    public SeguridadAgent(HttpClient httpClient)
        : base(httpClient, "api/Auth")
    {
    }

    public async Task<UsuarioDTO> GetByUsernameAsync(string username)
    {
        return await _httpClient.GetFromJsonAsync<UsuarioDTO>($"{_endpoint}/username/{username}");
    }
}