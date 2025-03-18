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

public class UsuarioAgent: BaseAgent, IUsuarioAgent
{
    private TokenManager _tokenManager;
    private IJSRuntime _jsRuntime;

    public UsuarioAgent(HttpClient httpClient, IJSRuntime jsRuntime)
        : base(httpClient, "api/Usuarios")
    {
        _tokenManager = new TokenManager(jsRuntime);
        _jsRuntime = jsRuntime;
    }
    
    public async Task<IEnumerable<UsuarioDTO>> GetAllExceptAsync(string email)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var listaUsuarios = 
            (await _httpClient.GetAsync($"{_endpoint}/GetAllExcept?email={email}"))
            .Content.ReadFromJsonAsync<ApiResponse<IEnumerable<UsuarioDTO>>>().Result;

        return listaUsuarios?.Message ?? new List<UsuarioDTO>();
    }
    public async Task<AdministrarRolesUsuarioDTO> GetAllRolesByIdAsync(string userId)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var rolesUsuario = 
            (await _httpClient.GetAsync($"api/RolesUsuarios/GetAllRolesById?userId={userId}"))
            .Content.ReadFromJsonAsync<ApiResponse<AdministrarRolesUsuarioDTO>>().Result;

        return rolesUsuario?.Message ?? new AdministrarRolesUsuarioDTO();
    }
    public async Task<UsuarioDTO> GetByIdAsync(string userId)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var usuario = 
            (await _httpClient.GetAsync($"{_endpoint}/GetById?userId={userId}"))
            .Content.ReadFromJsonAsync<ApiResponse<UsuarioDTO>>().Result;

        return usuario?.Message ?? new UsuarioDTO();
    }
    public async Task<bool> UpdateRolesById(string userId, AdministrarRolesUsuarioDTO model)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());
        
        var apiResponse = (await _httpClient.PutAsJsonAsync($"api/RolesUsuarios/UpdateRolesById?userId={userId}", model)).Content
            .ReadFromJsonAsync<ApiResponse<string>>().Result;
        return apiResponse?.Success ?? false;
    }
    public async Task<bool> DeleteAsync(string userId)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var eliminado = 
            (await _httpClient.DeleteAsync($"{_endpoint}/Delete?userId={userId}"))
            .Content.ReadFromJsonAsync<ApiResponse<bool>>().Result;

        return eliminado?.Success ?? false;
    }

    #region Gestión roles

     public async Task<IEnumerable<RolDTO>> GetAllRolesAsync()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var listaRoles = 
            (await _httpClient.GetAsync($"api/Roles/GetAll"))
            .Content.ReadFromJsonAsync<ApiResponse<IEnumerable<RolDTO>>>().Result;

        return listaRoles?.Message ?? new List<RolDTO>();
    }
     
    public async Task<ApiResponse<bool>> AddRoleAsync(RolDTO rol)
    {
        var apiResponse = (await _httpClient.PostAsJsonAsync($"api/Roles/Add", rol)).Content
            .ReadFromJsonAsync<ApiResponse<bool>>().Result;
        return apiResponse ?? new ApiResponse<bool>();
    }
    public async Task<bool> DeleteRoleAsync(string rolId)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var eliminado = 
            (await _httpClient.DeleteAsync($"api/Roles/Delete?rolId={rolId}"))
            .Content.ReadFromJsonAsync<ApiResponse<bool>>().Result;

        return eliminado?.Success ?? false;
    }

    #endregion

    #region Permisos

    public async Task<PermisoDTO> GetAllPermisosByRolIdAsync(string rolId)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _tokenManager.GetTokenAsync());

        var allPermisos = 
            (await _httpClient.GetAsync($"api/Permisos/GetALlPermisosByRolId?rolId={rolId}"))
            .Content.ReadFromJsonAsync<ApiResponse<PermisoDTO>>().Result;

        return allPermisos?.Message ?? new PermisoDTO();
    }
     
    public async Task<ApiResponse<bool>> UpdatePermisosAsync(PermisoDTO permisosRol)
    {
        var apiResponse = (await _httpClient.PutAsJsonAsync($"api/Permisos/UpdatePermisos", permisosRol)).Content
            .ReadFromJsonAsync<ApiResponse<bool>>().Result;
        return apiResponse ?? new ApiResponse<bool>();
    }

    #endregion
}