using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;

namespace AgroConecta.Domain.Sistema;

public class Terreno
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [ForeignKey("Usuario")]
    public string propietario_id { get; set; }
    
    public int tipo_medida_area_id { get; set; }
    
    public int tipo_suelo_id { get; set; }
    
    public double coordenada_latitud { get; set; }
    
    public double coordenada_longitud { get; set; }
    
    public double cantidad_area_suelo_total { get; set; }
    
    public double cantidad_area_suelo_disponible{ get; set; }
    
    [MaxLength(500)]
    public string comentario { get; set; }
    
    public bool registro_activo { get; set; }
    
    public int estado  { get; set; }
    
    //Propiedades navigacionales 
    
    public Usuario propietario { get; set; }

    public TipoMedidaArea tipo_medida_area { get; set; }
    
    public TipoSuelo tipo_suelo { get; set; }

    public ICollection<Arrendamiento>? arrendamientos { get; set; }

}