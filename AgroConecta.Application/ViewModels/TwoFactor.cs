using System.ComponentModel.DataAnnotations;

namespace AgroConecta.Application.ViewModels;

public class TwoFactor
{
    [Required]
    public string TwoFactorCode { get; set; }
}