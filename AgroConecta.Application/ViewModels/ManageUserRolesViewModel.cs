namespace AgroConecta.Application.Modelos;

public class ManageUserRolesViewModel
{
    public string UserId { get; set; }
    public IList<UserRolesViewModel> UserRoles { get; set; }
}