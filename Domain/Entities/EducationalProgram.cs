using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class EducationalProgram
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    /// <returns></returns>
    [Key]
    public Guid Uuid { get; set; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Статус ОП (всегда единственное значение)
    /// </summary>
    public string Status { get; set; }
    
    /// <summary>
    /// Шифр
    /// </summary>
    public string Cypher { get; set; }
    
    /// <summary>
    /// Уровни обучения
    /// </summary>
    public EducationalLevel Level { get; set; }
    
    /// <summary>
    /// Стандарт обучения
    /// </summary>
    /// <returns></returns>
    public EducationalStandart Standart { get; set; }
    
    /// <summary>
    /// Институт
    /// </summary>
    public Institute Institute { get; set; }
    
    /// <summary>
    /// Ответственное лицо
    /// </summary>
    public HeadUser Head { get; set; }
    
    /// <summary>
    /// Дата следующей аккредитации
    /// </summary>
    public DateTime AccreditationTime { get; set; }
    
    public ICollection<EducationalModule> EducationalModules { get; set; }
    
}