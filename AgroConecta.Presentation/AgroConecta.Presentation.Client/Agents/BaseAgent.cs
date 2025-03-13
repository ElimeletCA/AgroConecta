using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces;

namespace AgroConecta.Presentation.Client.Agents;

public class BaseAgent<T> : IBaseAgent<T>
{
    protected readonly HttpClient _httpClient;
    protected readonly string _endpoint;

    public BaseAgent(HttpClient httpClient, string endpoint)
    {
        _httpClient = httpClient;
        _endpoint = endpoint;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<T>>(_endpoint);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<T>($"{_endpoint}/{id}");
    }

    public async Task AddAsync(T entity)
    {
        await _httpClient.PostAsJsonAsync(_endpoint, entity);
    }

    public async Task UpdateAsync(int id, T entity)
    {
        await _httpClient.PutAsJsonAsync($"{_endpoint}/{id}", entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"{_endpoint}/{id}");
    }
}
