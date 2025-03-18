using System.Net.Http.Json;
using AgroConecta.Presentation.Client.Agents.Interfaces;

namespace AgroConecta.Presentation.Client.Agents;

public class BaseAgent: IBaseAgent
{
    protected readonly HttpClient _httpClient;
    protected readonly string _endpoint;

    public BaseAgent(HttpClient httpClient, string endpoint)
    {
        _httpClient = httpClient;
        _endpoint = endpoint;
    }

    
}
