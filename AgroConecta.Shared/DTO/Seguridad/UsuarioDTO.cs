namespace AgroConecta.Shared.DTO.Seguridad;

public class UsuarioDTO
{
    public string Id { get; set; } = string.Empty;
    //[Required(ErrorMessage = "El nombre completo es requerido")]
    //[RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜ ]{1,50}$", ErrorMessage = "Nombre completo inválido (ERROR-104)")]
    public string nombre_completo { get; set; } = string.Empty;
    
    //[Required(ErrorMessage = "La fecha de nacimiento es requerida")]
    //[DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
    public DateTime? fecha_nacimiento { get; set; }
    
    //[Required(ErrorMessage = "El usuario es requerido (ERROR-101)")]
    //[RegularExpression(@"^[a-zA-Z]{1,15}$", ErrorMessage = "Usuario inválido")]
    public string UserName { get; set; } = string.Empty;
    
    //[Required(ErrorMessage = "El correo electrónico es requerido")]
    //[EmailAddress(ErrorMessage = "Correo electrónico inválido")]
    public string Email { get; set; } = string.Empty;
    
    public bool remember_me { get; set; }
    
    //[Required(ErrorMessage = "La contraseña es requerida")]
    //[StringLength(25, MinimumLength = 8, ErrorMessage = "Contraseña inválida, requiere al menos 8 caracteres")]
    public string pasword_without_hash { get; set; } = string.Empty;
    
    public int[]? perfiles_id { get; set; }
    public string two_factor_code { get; set; } = string.Empty;
    
    
    //Propiedades navigacionales

    // public ICollection<Terreno>? terrenos { get; set; }
    //
    // public ICollection<Arrendamiento>? arrendamientos { get; set; }
    //
    // public ICollection<Proyecto>? proyectos { get; set; }
    // public ICollection<Perfil>? perfiles { get; set; }
    

}