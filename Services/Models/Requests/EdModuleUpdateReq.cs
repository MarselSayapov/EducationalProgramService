using System.ComponentModel.DataAnnotations;

namespace Services.Models;

public class EdModuleUpdateReq
{
    [Required]
    public required Guid Uuid { get; set; }
    
    [Required]
    public required string Title { get; set; }
    
    [Required]
    public required string Type { get; set; }
}