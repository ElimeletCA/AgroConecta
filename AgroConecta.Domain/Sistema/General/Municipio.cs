using AgroConecta.Domain.General;

namespace AgroConecta.Domain.Sistema.General;

public class Municipio : BaseEntity
{
    public string ProvinciaId { get; set; }

    public string Descripcion { get; set; }
    
    public double? Latitud { get; set; }
    public double? Longitud { get; set; }
    public Provincia Provincia { get; set; }
    public ICollection<Terreno> Terrenos { get; set; }

    
}