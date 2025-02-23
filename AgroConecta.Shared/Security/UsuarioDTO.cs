namespace AgroConecta.Shared.Security;

public class UsuarioDTO
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    //Aqui se colocan todos los demas datos que tenga el usuario como nombres, direcciones, fechas, edad, estados etc

    public string Username { get; set; } = string.Empty;
}