using System.ComponentModel.DataAnnotations;

namespace Services.Models.Response;

public class SignResp
{
    public Guid Id { get; set; }
    
    [Required]
    public required string Token { get; set; }
}