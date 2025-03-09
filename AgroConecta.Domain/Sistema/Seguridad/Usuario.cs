using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroConecta.Domain.System.Seguridad;

public class Usuario : IdentityUser 
{
    public string nombre_completo { get; set; } = string.Empty;
    public DateTime fecha_nacimiento { get; set; }
    

    [NotMapped]
    public string pasword_without_hash { get; set; }= string.Empty;

    [NotMapped]
    public string two_factor_code { get; set; }= string.Empty;
    
    //Propiedades navigacionales

    public ICollection<Terreno>? terrenos { get; set; }
    
    public ICollection<Arrendamiento>? arrendamientos { get; set; }
    
    public ICollection<Proyecto>? proyectos { get; set; }
    public ICollection<Perfil>? perfiles { get; set; }
    
    [NotMapped]
    public int[]? perfiles_id { get; set; }
}