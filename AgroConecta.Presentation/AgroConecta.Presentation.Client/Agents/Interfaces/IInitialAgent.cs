namespace AgroConecta.Presentation.Client.Agents.Interfaces;

public interface IInitialAgent: IBaseAgent
{
    public Task<string> GetDocument();
   
}