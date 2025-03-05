using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.System.Extras;

namespace AgroConecta.Domain.System;

public class TipoArchivo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [MaxLength(100)]
    public string descripcion { get; set; }
    
    public bool registro_activo { get; set; }
    
    public ICollection<Archivo>? archivos { get; set; }

}