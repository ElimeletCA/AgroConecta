namespace AgroConecta.Shared.DTO;

public class TerrenoDTO: BaseDTO
{
    public string PropietarioId { get; set; }
    
    public string TipoMedidaAreaId { get; set; }
    
    public string TipoSueloId { get; set; }
    
    public double CoordenadaLatitud { get; set; }
    
    public double CoordenadaLongitud { get; set; }
    
    public double CantidadAreaSueloTotal { get; set; }
    
    public double CantidadAreaSueloDisponible{ get; set; }
    
    public string Comentario { get; set; }
    
    
    public int Estado  { get; set; }

}