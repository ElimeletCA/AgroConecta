namespace AgroConecta.Shared.Seguridad.Mensajes;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T Message { get; set; }
}