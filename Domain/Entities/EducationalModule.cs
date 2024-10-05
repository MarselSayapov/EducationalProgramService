using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Модуль образовательной организации
/// </summary>
public class EducationalModule
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Uuid { get; set; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Тип модуля
    /// </summary>
    public string Type { get; set; }
    
    public Guid? EducationalProgramId { get; set; }

    public EducationalProgram? EducationalProgram { get; set; }
}