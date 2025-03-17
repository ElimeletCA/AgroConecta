using System.Net;
using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces;
using AgroConecta.Shared.DTO;
using AgroConecta.Shared.Seguridad.Mensajes;

namespace AgroConecta.Presentation.Client.Agents;

public abstract class InitialAgent<TDto> : BaseAgent, IInitialAgent<TDto>
    where TDto : BaseDTO
{
    protected InitialAgent(HttpClient httpClient, string endpoint) 
        : base(httpClient, endpoint)
    {
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_endpoint);
        
        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<TDto>>>();
            return apiResponse?.Message ?? Enumerable.Empty<TDto>();
        }
        
        HandleErrorResponse(response);
        return Enumerable.Empty<TDto>();
    }

    public async Task<TDto?> GetByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
        
        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<TDto>>();
            return apiResponse?.Message;
        }
        
        HandleErrorResponse(response);
        return default;
    }

    public async Task<bool> AddAsync(TDto dto)
    {
        dto.Id = String.Empty;
        var response = await _httpClient.PostAsJsonAsync(_endpoint, dto);
        
        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<TDto>>();
            return apiResponse?.Success ?? false;
        }
        
        HandleErrorResponse(response);
        return false;
    }

    public async Task UpdateAsync(string id, TDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{id}", dto);
        
        if (!response.IsSuccessStatusCode)
        {
            HandleErrorResponse(response);
        }
    }

    public async Task SoftDeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{_endpoint}/soft/{id}");
        
        if (!response.IsSuccessStatusCode)
        {
            HandleErrorResponse(response);
        }
    }

    public async Task HardDeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{_endpoint}/hard/{id}");
        
        if (!response.IsSuccessStatusCode)
        {
            HandleErrorResponse(response);
        }
    }

    private void HandleErrorResponse(HttpResponseMessage response)
    {
        // Implementar lógica de manejo de errores
        var statusCode = response.StatusCode;
        var errorContent = response.Content.ReadAsStringAsync().Result;
        
        throw new HttpRequestException(
            $"Error: {statusCode} - {errorContent}"
        );
    }
}