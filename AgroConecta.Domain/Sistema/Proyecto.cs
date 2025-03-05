using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.System.Seguridad;

namespace AgroConecta.Domain.System;

public class Proyecto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public int arrendamiento_id { get; set; }
    
    public string inversionista_id { get; set; }
    
    public int tipo_cultivo_id { get; set; }
    
    public DateTime fecha_inicio { get; set; }
    
    public DateTime fecha_fin { get; set; }
    
    public string nombre { get; set; }
    
    public string descripcion { get; set; }

    public decimal monto_total_presupuesto { get; set; }
    
    public string objetivos { get; set; }

    public string resultados_esperados { get; set; }
    
    public decimal monto_total_retorno_estimado { get; set; }

    [MaxLength(500)]
    public string comentario { get; set; }
    
    public bool registro_activo { get; set; }
    
    public int estado  { get; set; }

    //Propiedades navigacionales 

    
    public Usuario inversionista { get; set; }

    public Arrendamiento arrendamiento { get; set; }
    
    public TipoCultivo tipo_cultivo { get; set; }
}