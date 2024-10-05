using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http.Timeouts;

namespace Services.Models;

public class EdProgramReq
{
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string Status { get; set; }
    
    [Required]
    public required string Cypher { get; set; }
    
    public EducationalLevel Level { get; set; }
    
    public EducationalStandart Standart { get; set; }
    
    public Guid InstituteId { get; set; }
    
    public Guid HeadId { get; set; }
    
    public DateTime AccreditationTime { get; set; }
}