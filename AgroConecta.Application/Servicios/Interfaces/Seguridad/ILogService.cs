using AgroConecta.Shared.DTO;

namespace AgroConecta.Application.Servicios.Interfaces.Seguridad;

public interface ILogService
{
    Task LogInformation(
        string action, 
        string message, 
        string userEmail,
        object parameters = null, 
        object data = null
    );
    Task LogWarning(
        string action, 
        string message, 
        string userEmail,
        object parameters = null, 
        object data = null
    );
    
    Task LogError(
        string action, 
        Exception ex,
        string userEmail,
        object parameters = null, 
        object data = null
    );
    Task<List<SystemLogDTO>> GetAllLogsAsync();
    Task DeleteOldLogsAsync(int daysToKeep);
    Task KeepOnlyRecentLogsAsync(int numberOfLogsToKeep);



}