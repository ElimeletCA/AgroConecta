using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConecta.Domain.Sistema.Tipos;

public class TipoArrendamiento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [MaxLength(100)]
    public string descripcion { get; set; }
    
    public bool registro_activo { get; set; }
    
    public ICollection<Arrendamiento>? arrendamientos { get; set; }

}