using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;
using AgroConecta.Domain.Sistema.Extras;

namespace AgroConecta.Domain.Sistema.Tipos;

public class TipoArchivo : BaseEntity
{
    
    [MaxLength(100)]
    public required string Descripcion { get; set; }
    
    public ICollection<Archivo>? Archivos { get; set; }

}