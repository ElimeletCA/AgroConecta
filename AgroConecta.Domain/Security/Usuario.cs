namespace AgroConecta.Domain.Security;

public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Rol { get; set; } = "Usuario";
    //Aqui se colocan todos los demas datos que tenga el usuario como nombres, direcciones, fechas, edad, estados etc
    public string Username { get; set; } = string.Empty;

}