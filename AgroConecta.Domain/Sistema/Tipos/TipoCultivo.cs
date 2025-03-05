using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AgroConecta.Domain.System;

public class TipoCultivo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [MaxLength(100)]
    public string descripcion { get; set; }
    
    public bool registro_activo { get; set; }
    
    public ICollection<Proyecto>? proyectos { get; set; }

}