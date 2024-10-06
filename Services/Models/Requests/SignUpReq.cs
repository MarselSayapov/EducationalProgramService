using System.ComponentModel.DataAnnotations;

namespace Services.Models;

public class SignUpReq
{
    [Required]
    public required string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }
}