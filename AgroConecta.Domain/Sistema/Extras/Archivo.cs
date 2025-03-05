
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConecta.Domain.System.Extras;

public class Archivo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public int tipo_archivo_id { get; set; }
    
    public int referencia_id { get; set; }
    
    public string nombre_archivo { get; set; }
    
    public string url_archivo { get; set; }

    public DateTime fecha_creacion { get; set; }
    
    public string descripcion { get; set; }
    
    public string formato { get; set; }

    public string size { get; set; }
    
    public int estado  { get; set; }
    
    public TipoArchivo tipo_archivo { get; set; }

}