using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    [Key]
    public Guid Uuid { get; set; }
    public required string Email { get; set; }
    
    public required string Name { get; set; }
    
    public required string Password { get; set; }
    
    public List<EducationalProgram> EducationalPrograms { get; set; }
}