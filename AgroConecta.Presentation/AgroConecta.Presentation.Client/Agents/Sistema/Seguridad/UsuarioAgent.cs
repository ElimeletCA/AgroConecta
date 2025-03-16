using System.Net.Http.Headers;
using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;
using AgroConecta.Presentation.Client.Agents.Interfaces.Sistema.Seguridad;
using AgroConecta.Presentation.Client.Helpers.Seguridad;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Sistema.Seguridad;

public class UsuarioAgent: BaseAgent<UsuarioDTO>, IUsuarioAgent
{
    private TokenManager _tokenManager;
    private IJSRuntime _jsRuntime;

    public UsuarioAgent(HttpClient httpClient, IJSRuntime jsRuntime)
        : base(httpClient, "api/Usuarios")
    {
        _tokenManager = new TokenManager(jsRuntime);
        _jsRuntime = jsRuntime;
    }
    
    public async Task<IEnumerable<UsuarioDTO>> GetAllExcept(string email)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var listaUsuarios = 
            (await _httpClient.GetAsync($"{_endpoint}/GetAllExcept?email={email}"))
            .Content.ReadFromJsonAsync<ApiResponse<IEnumerable<UsuarioDTO>>>().Result;

        return listaUsuarios?.message ?? new List<UsuarioDTO>();
    }
    public async Task<AdministrarRolesUsuarioDTO> GetAllRolesById(string userId)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var rolesUsuario = 
            (await _httpClient.GetAsync($"{_endpoint}/GetAllRolesById?userId={userId}"))
            .Content.ReadFromJsonAsync<ApiResponse<AdministrarRolesUsuarioDTO>>().Result;

        return rolesUsuario?.message ?? new AdministrarRolesUsuarioDTO();
    }
}