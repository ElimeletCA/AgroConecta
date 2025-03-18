using System.Text.Json;
using AgroConecta.Application.Servicios.Interfaces.Seguridad;
using AgroConecta.Application.Servicios.Interfaces.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Auditoria;
using AgroConecta.Infrastructure.Repositorios.Data;
using AgroConecta.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace AgroConecta.Application.Servicios.Seguridad;

public class LogService: ILogService
{
    private readonly AppDbContext _context;

    public LogService(AppDbContext context)
    {
        _context = context;
    }

    public async Task LogInformation(
        string action, 
        string message, 
        string userEmail,
        object parameters = null, 
        object data = null)
    {
        await CreateLog(
            level: "Info",
            action: action,
            message: message,
            userEmail: userEmail,
            parameters: parameters,
            data: data
        );
    }
    public async Task LogWarning(
        string action, 
        string message, 
        string userEmail,
        object parameters = null, 
        object data = null)
    {
        await CreateLog(
            level: "Warning",
            action: action,
            message: message,
            userEmail: userEmail,
            parameters: parameters,
            data: data
        );
    }
    public async Task LogError(
        string action, 
        Exception ex,
        string userEmail,
        object parameters = null, 
        object data = null)
    {
        await CreateLog(
            level: "Error",
            action: action,
            message: ex.Message,
            exception: ex,
            userEmail: userEmail,
            parameters: parameters,
            data: data
        );
    }

    private async Task CreateLog(
        string level,
        string action,
        string message,
        Exception exception = null,
        string userEmail = null,
        object parameters = null,
        object data = null)
    {
        var log = new SystemLog
        {
            Level = level,
            Action = action,
            Message = message,
            Exception = exception?.ToString(),
            UserEmail = userEmail,
            Parameters = parameters != null ? JsonSerializer.Serialize(parameters) : null,
            AdditionalData = data != null ? JsonSerializer.Serialize(data) : null,
            Timestamp = DateTime.UtcNow
        };

        await _context.SystemLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }
    public async Task<List<SystemLogDTO>> GetAllLogsAsync()
    {
        var logs = await _context.SystemLogs
            .OrderByDescending(log => log.Timestamp)
            .ToListAsync(); // Primero trae los datos
    
        TimeSpan offset = new TimeSpan(-4, 0, 0);
    
        return logs.Select(log => new SystemLogDTO
        {
            Timestamp = new DateTime(log.Timestamp.Ticks, DateTimeKind.Utc)
                .Add(offset) // Aplica el offset UTC-4
                .ToString("dd-MM-yyyy HH:mm:ss"), // Opcional: Formatear como string
            Level = log.Level,
            Action = log.Action,
            Message = log.Message,
            Exception = log.Exception,
            UserEmail = log.UserEmail,
            Parameters = log.Parameters,
            AdditionalData = log.AdditionalData
        }).ToList();
    }
    public async Task DeleteOldLogsAsync(int daysToKeep)
    {
        if (daysToKeep < 1)
        {
            throw new ArgumentException("El número de días debe ser al menos 1", nameof(daysToKeep));
        }

        var cutoffDate = DateTime.UtcNow.AddDays(-daysToKeep);
    
        await _context.SystemLogs
            .Where(log => log.Timestamp < cutoffDate)
            .ExecuteDeleteAsync();
    }
    
    public async Task KeepOnlyRecentLogsAsync(int numberOfLogsToKeep)
    {
        if (numberOfLogsToKeep < 1)
        {
            throw new ArgumentException("Debe conservar al menos 1 log", nameof(numberOfLogsToKeep));
        }

        // Obtener los IDs de los logs más recientes
        var recentLogIds = await _context.SystemLogs
            .OrderByDescending(log => log.Timestamp)
            .Take(numberOfLogsToKeep)
            .Select(log => log.Id)
            .ToListAsync();

        // Eliminar todos los logs excepto los recientes
        await _context.SystemLogs
            .Where(log => !recentLogIds.Contains(log.Id))
            .ExecuteDeleteAsync();
    }
    
}