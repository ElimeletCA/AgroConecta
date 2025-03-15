using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;

namespace AgroConecta.Domain.Sistema;

public class Arrendamiento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public int terreno_id { get; set; }
    
    public string agricultor_id { get; set; }
    
    public int tipo_arrendamiento_id { get; set; }
    
    public DateTime fecha_inicio { get; set; }
    
    public DateTime fecha_fin { get; set; }
    
    [MaxLength(500)]
    public string condiciones { get; set; }
    
    public double cantidad_area_suelo_arrendada { get; set; }
    
    public decimal monto_pago{ get; set; }
    
    public string frecuencia_pago { get; set; }
    
    [MaxLength(500)]
    public string comentario { get; set; }
    
    public bool registro_activo { get; set; }
    
    public int estado  { get; set; }
    
    //Propiedades navigacionales 

    
    public Usuario agricultor { get; set; }

    public Terreno terreno { get; set; }
    
    public TipoArrendamiento tipo_arrendamiento { get; set; }
    
    public ICollection<Proyecto>? proyectos { get; set; }


}