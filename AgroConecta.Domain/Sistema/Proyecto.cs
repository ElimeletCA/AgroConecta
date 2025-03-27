using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;

namespace AgroConecta.Domain.Sistema;

public class Proyecto : BaseEntity
{


    public string ArrendamientoId { get; set; }
    
    public string InversionistaId { get; set; }
    
    public string TipoCultivoId { get; set; }
    
    public DateTime FechaInicio { get; set; }
    
    public DateTime FechaFin { get; set; }
    
    public string Nombre { get; set; }
    
    public string Descripcion { get; set; }

    public decimal MontoTotalPresupuesto { get; set; }
    
    public string Objetivos { get; set; }

    public string ResultadosEsperados { get; set; }
    
    public decimal MontoTotalRetornoEstimado { get; set; }

    [MaxLength(500)]
    public string? Comentario { get; set; }
    
    
    public int Estado  { get; set; }

    //Propiedades navigacionales 

    
    public Usuario Inversionista { get; set; }

    public Arrendamiento Arrendamiento { get; set; }
    
    public TipoCultivo TipoCultivo { get; set; }
}