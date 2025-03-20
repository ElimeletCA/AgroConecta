using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;

namespace AgroConecta.Domain.Sistema.Tipos;

public class TipoArrendamiento: BaseEntity
{
    
    [MaxLength(100)]
    public required string Descripcion { get; set; }
    
    public ICollection<Arrendamiento>? Arrendamientos { get; set; }

}