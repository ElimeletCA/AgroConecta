namespace AgroConecta.Presentation.Client.Agents.Interfaces.Interfaces;

public interface IInitialAgent: IBaseAgent
{
    public Task<string> GetDocument();
   
}