using Domain.Entities;
using Domain.Enums;

namespace Services.Models.Response;

public class EdProgramResp
{
    public Guid Uuid { get; set; }
    
    public required string Title { get; set; }
    
    public required string Status { get; set; }
    
    public required string Cypher { get; set; }
    
    public EducationalLevel Level { get; set; }
    
    public EducationalStandart Standart { get; set; }
    
    public Institute Institute { get; set; }
    
    public HeadUser HeadUser { get; set; }
    
    public DateTime AccreditationTime { get; set; }
}