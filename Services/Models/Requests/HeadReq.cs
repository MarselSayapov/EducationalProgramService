using System.ComponentModel.DataAnnotations;

namespace Services.Models;

public class HeadReq
{
    [Required]
    public required string FullName { get; set; }
}