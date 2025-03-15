using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Seguridad;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Client.Agents.Sistema.Seguridad;

public class UsuarioAgent: BaseAgent<UsuarioDTO>, IUsuarioAgent
{
    public UsuarioAgent(HttpClient httpClient)
        : base(httpClient, "api/Usuarios")
    {
    }
    
    public async Task<IEnumerable<UsuarioDTO>> GetAllExcept(string email)
    {
        var listaUsuarios = 
            (await _httpClient.GetAsync($"{_endpoint}/GetAllExcept?email={email}"))
            .Content.ReadFromJsonAsync<ApiResponse<IEnumerable<UsuarioDTO>>>().Result;

        return listaUsuarios?.message ?? new List<UsuarioDTO>();
    }
}