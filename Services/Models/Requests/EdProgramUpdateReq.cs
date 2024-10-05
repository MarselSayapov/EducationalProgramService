using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Domain.Enums;

namespace Services.Models;

public class EdProgramUpdateReq
{
    [Required]
    public Guid Uuid { get; set; }
    
    public string Title { get; set; }
    
    public string Status { get; set; }
    
    public string Cypher { get; set; }

    public EducationalLevel Level { get; set; }

    public EducationalStandart Standart { get; set; }

    public Guid InstituteId { get; set; }

    public Guid HeadId { get; set; }
    
    public DateTime AccreditationTime { get; set; }
    
}