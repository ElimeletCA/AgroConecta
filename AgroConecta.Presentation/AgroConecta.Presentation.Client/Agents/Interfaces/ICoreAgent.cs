namespace AgroConecta.Presentation.Client.Agents.Interfaces;

public interface ICoreAgent
{
    public Task<string> GetDocument();
/*public class CoreAgent
    public InitialAgent(HttpClient _httpClient) : base(_httpClient) { }



    public async Task<string> GetDocument()
    {
        var url = $"Pdf/GeneratePdf";
        var baseAddres = httpClient?.BaseAddress?.ToString();
        var cuentas =  await httpClient.GetStringAsync(url);
        return cuentas;
    }


}*/
}