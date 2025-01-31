using Microsoft.AspNetCore.Identity;

namespace AgroConecta.Presentation.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public override bool EmailConfirmed { get; set; }
}