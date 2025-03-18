using System.ComponentModel.DataAnnotations;
using AgroConecta.Domain.General;

namespace AgroConecta.Domain.Sistema.Auditoria;

public class SystemLog : BaseEntity
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
    [MaxLength(50)]
    public string Level { get; set; }  // Info, Warning, Error
        
    [MaxLength(200)]
    public string Action { get; set; }  // Nombre del controlador/método
        
    public string Message { get; set; }
    public string? Exception { get; set; }
        
    [MaxLength(450)]
    public string UserEmail { get; set; }
        
    public string? Parameters { get; set; }  // JSON con parámetros
    public string? AdditionalData { get; set; }  // JSON con datos adicionales
}