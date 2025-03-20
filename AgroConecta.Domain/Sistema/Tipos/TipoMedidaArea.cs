using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;

namespace AgroConecta.Domain.Sistema.Tipos;

public class TipoMedidaArea : BaseEntity
{
    
    [MaxLength(100)]
    public required string Descripcion { get; set; }

    //Propiedades navigacionales

    public ICollection<Terreno>? Terrenos { get; set; }


}