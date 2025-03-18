namespace AgroConecta.Presentation.Client.Helpers;

public static class FormatStrings
{
    /// <summary>
    /// Transforma la descripción de un permiso para mostrarlo adecuadamente ej:
    /// Valor: Permisos.Terrenos.Ver
    /// Resultado: Ver Terrenos
    /// </summary>
    /// <param name="permiso"></param>
    /// <returns></returns>
    public static string VisualizarPermiso(string permiso)
    {
        var partes = permiso.Split('.');

        if (partes.Length < 3)
        {
            return permiso; 
        }

        var recurso = partes[1]; 
        var accion = partes[2];
        return $"{accion} {recurso}";
    } 
}