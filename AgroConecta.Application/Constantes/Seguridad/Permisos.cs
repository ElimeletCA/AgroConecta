namespace AgroConecta.Application.Constantes.Seguridad;

public class Permisos
{
    public static List<string> GenerarPermisosParaModulo(string modulo)
    {
        return new List<string>()
        {
            $"Permisos.{modulo}.Ver",
            $"Permisos.{modulo}.Crear",
            $"Permisos.{modulo}.Editar",
            $"Permisos.{modulo}.Eliminar",
        };
    }

    public static class Terrenos
    {
        public const string Ver = "Permisos.Terrenos.Ver";
        public const string Crear = "Permisos.Terrenos.Crear";
        public const string Editar = "Permisos.Terrenos.Editar";
        public const string Eliminar = "Permisos.Terrenos.Eliminar";
    }
    public static class Arrendamientos
    {
        public const string Ver = "Permisos.Arrendamientos.Ver";
        public const string Crear = "Permisos.Arrendamientos.Crear";
        public const string Editar = "Permisos.Arrendamientos.Editar";
        public const string Eliminar = "Permisos.Arrendamientos.Eliminar";
    }
    public static class Proyectos
    {
        public const string Ver = "Permisos.Proyectos.Ver";
        public const string Crear = "Permisos.Proyectos.Crear";
        public const string Editar = "Permisos.Proyectos.Editar";
        public const string Eliminar = "Permisos.Proyectos.Eliminar";
    }
    public static class Roles
    {
        public const string Ver = "Permisos.Roles.Ver";
        public const string Crear = "Permisos.Roles.Crear";
        public const string Editar = "Permisos.Roles.Editar";
        public const string Eliminar = "Permisos.Roles.Eliminar";
    }
    public static class Usuarios
    {
        public const string Ver = "Permisos.Usuarios.Ver";
        public const string Crear = "Permisos.Usuarios.Crear";
        public const string Editar = "Permisos.Usuarios.Editar";
        public const string Eliminar = "Permisos.Usuarios.Eliminar";
    }
}