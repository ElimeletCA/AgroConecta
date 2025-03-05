using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConecta.Domain.System.Seguridad;

public class Perfil
{
    [Key]
    public int id { get; set; }

    [Required]
    public string nombre_perfil { get; set; } = string.Empty;

    public string? descripcion_perfil { get; set; }
    
    private ICollection<Usuario>? usuarios { get; set; }

}