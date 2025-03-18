using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;

namespace AgroConecta.Domain.Sistema;

public class Arrendamiento : BaseEntity
{

    public string TerrenoId { get; set; }
    
    public string AgricultorId { get; set; }
    
    public string TipoArrendamientoId { get; set; }
    
    public DateTime FechaInicio { get; set; }
    
    public DateTime FechaFin { get; set; }
    
    [MaxLength(500)]
    public string Condiciones { get; set; }
    
    public double CantidadAreaSueloArrendada { get; set; }
    
    public decimal MontoPago{ get; set; }
    
    public string FrecuenciaPago { get; set; }
    
    [MaxLength(500)]
    public string Comentario { get; set; }
    
    
    public int Estado  { get; set; }
    
    //Propiedades navigacionales 

    
    public Usuario Agricultor { get; set; }

    public Terreno Terreno { get; set; }
    
    public TipoArrendamiento TipoArrendamiento { get; set; }
    
    public ICollection<Proyecto>? Proyectos { get; set; }


}