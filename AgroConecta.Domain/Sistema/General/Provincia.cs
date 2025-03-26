using AgroConecta.Domain.General;

namespace AgroConecta.Domain.Sistema.General;

public class Provincia : BaseEntity
{
    public string Descripcion { get; set; }

    public double? Latitud { get; set; }
    public double? Longitud { get; set; }
    
    public ICollection<Municipio> Municipios { get; set; }
}