using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
/// <summary>
/// Ответственное лицо
/// </summary>
public class HeadUser
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Uuid { get; set; }
    
    /// <summary>
    /// Полное имя
    /// </summary>
    public string FullName { get; set; }
}