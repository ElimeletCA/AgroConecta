namespace AgroConecta.Shared.DTO;

public class SystemLogDTO : BaseDTO
{
    public string Timestamp { get; set; }
    public string Level { get; set; }
    public string Action { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; } // Opcional si quieres mostrar excepciones
    public string UserEmail { get; set; }
    public string Parameters { get; set; } // JSON como string
    public string AdditionalData { get; set; } // JSON como string
    
    public string Descripcion => $"{Level} - {Action}";

}