using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AgroConecta.Domain.System;

public class TipoMedidaArea
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [MaxLength(100)]
    public string descripcion { get; set; }

    public bool registro_activo { get; set; }
    //Propiedades navigacionales

    public ICollection<Terreno>? terrenos { get; set; }


}