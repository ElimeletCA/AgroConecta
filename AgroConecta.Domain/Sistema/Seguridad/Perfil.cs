using System.ComponentModel.DataAnnotations;
using AgroConecta.Domain.General;

namespace AgroConecta.Domain.Sistema.Seguridad;

public class Perfil : BaseEntity

{
    [Required]
    public string NombrePerfil { get; set; } = string.Empty;

    public string? DescripcionPerfil { get; set; }
    
    private ICollection<Usuario>? Usuarios { get; set; }

}