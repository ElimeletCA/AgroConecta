using AgroConecta.Presentation.Client.Agents.Interfaces;

namespace AgroConecta.Presentation.Client.Agents;

public class BaseAgent : IBaseAgent
{
    protected readonly HttpClient httpClient;

    public BaseAgent(HttpClient _httpClient)
    {
        httpClient = _httpClient;
    }
}