using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces;
using AgroConecta.Presentation.Client.Agents.Interfaces.Seguridad;
using AgroConecta.Shared.Seguridad;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Client.Agents.Seguridad;

public class SeguridadAgent : BaseAgent<UsuarioDTO>, ISeguridadAgent
{
    public SeguridadAgent(HttpClient httpClient)
        : base(httpClient, "api/Auth")
    {
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
}