namespace AgroConecta.Shared.DTO;

public class TerrenoDTO: BaseDTO
{
    public string PropietarioId { get; set; }
    
    public string TipoMedidaAreaId { get; set; }
    
    public string TipoSueloId { get; set; }
    public string MunicipioId { get; set; }

    public string ProvinciaId { get; set; }

    public string Descripcion { get; set; }

    public double CoordenadaLatitud { get; set; }
    
    public double CoordenadaLongitud { get; set; }
    
    public double? CantidadAreaSueloTotal { get; set; }
    
    public double CantidadAreaSueloDisponible{ get; set; }
    public decimal? PrecioPorArea{ get; set; }

    public string? Comentario { get; set; }
    
    public string? DescripcionProvincia { get; set; }
    public string? DescripcionMunicipio { get; set; }
    public string? RutaImagen { get; set; }


    public int Estado  { get; set; }

}