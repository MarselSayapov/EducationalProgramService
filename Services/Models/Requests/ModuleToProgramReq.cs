using System.ComponentModel.DataAnnotations;

namespace Services.Models;

public class ModuleToProgramReq
{
    [Required]
    public required Guid programUuId { get; set; }
    
    [Required]
    public required Guid moduleUuId { get; set; }
}