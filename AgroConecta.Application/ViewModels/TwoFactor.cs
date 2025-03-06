using System.ComponentModel.DataAnnotations;
namespace AgroConecta.Application.Modelos;

public class TwoFactor
{
    [Required]
    public string TwoFactorCode { get; set; }
}