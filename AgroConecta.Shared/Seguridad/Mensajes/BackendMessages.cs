namespace AgroConecta.Shared.Seguridad.Mensajes;

public static class BackendMessages
{
    /// <summary>
    /// CODE-S000: Ha ocurrido un error, por favor contacte a soporte técnico.
    /// </summary>
    public static BackendMessage MessageS000 = new(){Tipo=(int)TipoMensaje.Error, Codigo= "CODE-S000", Descripcion = "Ha ocurrido un error, por favor contacte a soporte técnico."};

    /// <summary>
    /// CODE-S001: No existe el usuario en el sistema
    /// </summary>
    public static BackendMessage MessageS001 = new(){Tipo=(int)TipoMensaje.Error, Codigo= "CODE-S001", Descripcion = "No existe el usuario en el sistema."};
    
    /// <summary>
    /// CODE-S002: El correo electrónico del usuario aún no ha sido verificado, realice la verificación o contacte a soporte técnico
    /// </summary>
    public static BackendMessage MessageS002 = new(){Tipo=(int)TipoMensaje.Error, Codigo= "CODE-S002", Descripcion = "El correo electrónico del usuario aún no ha sido verificado, realice la verificación o contacte a soporte técnico."};
   
    /// <summary>
    /// CODE-S003: Se ha enviado un código de autenticación de dos factores (2FA) a su correo electrónico registrado. Por favor, revise su bandeja de entrada y utilice el código proporcionado para completar su inicio de sesión.
    /// </summary>
    public static BackendMessage MessageS003 = new(){Tipo=(int)TipoMensaje.Exito, Codigo= "CODE-S003", Descripcion = "Se ha enviado un código de autenticación de dos factores (2FA) a su correo electrónico registrado. Por favor, revise su bandeja de entrada y utilice el código proporcionado para completar su inicio de sesión."};

    /// <summary>
    /// CODE-S004: Ha ocurrido un error al enviar un código de autenticación de dos factores (2FA) a su correo, Por favor, intente de nuevo o contacte a soporte técnico.
    /// </summary>
    public static BackendMessage MessageS004 = new(){Tipo=(int)TipoMensaje.Error, Codigo= "CODE-S004", Descripcion = "Ha ocurrido un error al enviar un código de autenticación de dos factores (2FA) a su correo, Por favor, intente de nuevo o contacte a soporte técnico."};
    /// <summary>
    /// CODE-S005: Usuario o contraseña incorrectos, por favor verifique los datos e intente de nuevo.
    /// </summary>
    public static BackendMessage MessageS005 = new(){Tipo=(int)TipoMensaje.Error, Codigo= "CODE-S005", Descripcion = "Usuario o contraseña incorrectos, por favor verifique los datos e intente de nuevo."};

}

public class BackendMessage
{
    public int Tipo{ get; set; }
    public string Codigo{ get; set; }
    public string Descripcion{ get; set; }
}