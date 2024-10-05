using System.ComponentModel.DataAnnotations;

namespace Services.Models;

public class InstituteReq
{
    [Required]
    public required string Title { get; set; }
    
}