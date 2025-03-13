namespace AgroConecta.Shared.Seguridad.Mensajes;

public class ApiResponse<T>
{
    public bool success { get; set; }
    public T message { get; set; }
}