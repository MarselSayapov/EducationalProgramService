namespace Domain.Entities;

/// <summary>
/// Модуль образовательной организации
/// </summary>
public class EducationalModule
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Uuid { get; set; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Тип модуля
    /// </summary>
    public string Type { get; set; }
    
    
}