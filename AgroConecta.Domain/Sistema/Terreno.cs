using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgroConecta.Domain.General;
using AgroConecta.Domain.Sistema.General;
using AgroConecta.Domain.Sistema.Seguridad;
using AgroConecta.Domain.Sistema.Tipos;

namespace AgroConecta.Domain.Sistema;

public class Terreno: BaseEntity
{
    [ForeignKey("Usuario")]
    public string PropietarioId { get; set; }
    
    public string TipoMedidaAreaId { get; set; }
    
    public string MunicipioId { get; set; }

    [MaxLength(500)]
    public string Descripcion { get; set; }
    public string TipoSueloId { get; set; }
    
    public double CoordenadaLatitud { get; set; }
    
    public double CoordenadaLongitud { get; set; }
    
    public double CantidadAreaSueloTotal { get; set; }
    
    public double CantidadAreaSueloDisponible{ get; set; }
    
    public decimal PrecioPorArea{ get; set; }

    
    [MaxLength(500)]
    public string? Comentario { get; set; }
    
    
    public int estado  { get; set; }
    
    //Propiedades navigacionales 
    
    public Usuario Propietario { get; set; }

    public TipoMedidaArea TipoMedidaArea { get; set; }
    
    public TipoSuelo TipoSuelo { get; set; }

    public Municipio Municipio { get; set; }

    public ICollection<Arrendamiento>? Arrendamientos { get; set; }

}