using System.Net.Http.Headers;
using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces;
using AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;
using AgroConecta.Presentation.Client.Helpers.Seguridad;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;
using Microsoft.JSInterop;

namespace AgroConecta.Presentation.Client.Agents.Seguridad;

public class SeguridadAgent : BaseAgent, ISeguridadAgent
{
    private TokenManager _tokenManager;
    private IJSRuntime _jsRuntime;
    public SeguridadAgent(HttpClient httpClient,IJSRuntime jsRuntime)
        : base(httpClient, "api/Auth")
    {
        _tokenManager = new TokenManager(jsRuntime);
        _jsRuntime = jsRuntime;
    }
    public async Task<ApiResponse<BackendMessage>> RegisterUser(UsuarioDTO usuario)
    {
        var apiResponse = (await _httpClient.PostAsJsonAsync($"{_endpoint}/Registro", usuario)).Content
            .ReadFromJsonAsync<ApiResponse<BackendMessage>>().Result;
        return apiResponse ?? new ApiResponse<BackendMessage>();
    }
    public async Task<ApiResponse<BackendMessage>> LoginUser(UsuarioDTO usuario)
    {
        var apiResponse = (await _httpClient.PostAsJsonAsync($"{_endpoint}/Login", usuario)).Content
            .ReadFromJsonAsync<ApiResponse<BackendMessage>>().Result;
        return apiResponse ?? new ApiResponse<BackendMessage>();
    }
    public async Task<ApiResponse<BackendMessage>> Verificar2FA(UsuarioDTO usuario)
    {
        var apiResponse = (await _httpClient.PostAsJsonAsync($"{_endpoint}/Verificar2FA", usuario)).Content
            .ReadFromJsonAsync<ApiResponse<BackendMessage>>().Result;
        return apiResponse ?? new ApiResponse<BackendMessage>();
    }
    public async Task<IEnumerable<SystemLogDTO>> VerTodosLosLogs()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var allLogs = 
            (await _httpClient.GetAsync($"api/Logs"))
            .Content.ReadFromJsonAsync<IEnumerable<SystemLogDTO>>().Result;

        return allLogs ?? new List<SystemLogDTO>();
    }
    public async Task MantenerLogsRecientes(int cantidad)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var allLogs =
            (await _httpClient.DeleteAsync($"api/Logs/keep-recent/{cantidad}"));
    }
}