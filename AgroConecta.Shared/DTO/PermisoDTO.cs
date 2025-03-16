namespace AgroConecta.Shared.DTO;

public class PermisoDTO
{
    public string RolId { get; set; }
    public IList<FuncionesRolDTO> FuncionesRol { get; set; }
}
public class FuncionesRolDTO
{
    public string Tipo { get; set; }
    public string Valor { get; set; }
    public bool Asignada { get; set; }
}