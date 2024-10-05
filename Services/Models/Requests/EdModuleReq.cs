using System.ComponentModel.DataAnnotations;

namespace Services.Models;

public class EdModuleReq
{
    [Required]
    public required string Title { get; set; }
    
    [Required]
    public required string Type { get; set; }
}