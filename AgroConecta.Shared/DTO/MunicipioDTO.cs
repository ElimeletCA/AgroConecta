namespace AgroConecta.Shared.DTO;

public class MunicipioDTO : BaseDTO
{
    public string ProvinciaId { get; set; }

    public string Descripcion { get; set; }
    
    public double? Latitud { get; set; }
    public double? Longitud { get; set; }
}