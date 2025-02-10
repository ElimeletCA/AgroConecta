using AgroConecta.Presentation.Client.Agents.Interfaces.Interfaces;

namespace AgroConecta.Presentation.Client.Agents.Interfaces;

public class BaseAgent : IBaseAgent
{
    protected readonly HttpClient httpClient;

    public BaseAgent(HttpClient _httpClient)
    {
        httpClient = _httpClient;
    }
}