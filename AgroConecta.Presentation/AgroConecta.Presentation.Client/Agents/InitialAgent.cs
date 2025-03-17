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
        var response = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<TDto>>>($"{_endpoint}");
        return response?.Message ?? Enumerable.Empty<TDto>();
    }

    public async Task<TDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetFromJsonAsync<TDto>($"{_endpoint}/{id}");
    }

    public async Task<bool> AddAsync(TDto dto)
    {
        var apiResponse = (await _httpClient.PostAsJsonAsync($"{_endpoint}", dto)).Content
            .ReadFromJsonAsync<ApiResponse<TDto>>().Result;
        
        return apiResponse?.Success ??false;
    }

    public async Task UpdateAsync(string id, TDto dto)
    {
        await _httpClient.PutAsJsonAsync($"{_endpoint}/{id}", dto);
    }

    public async Task SoftDeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_endpoint}/soft/{id}");
    }

    public async Task HardDeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_endpoint}/hard/{id}");
    }
}