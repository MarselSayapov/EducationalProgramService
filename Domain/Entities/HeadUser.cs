using System;

namespace Domain.Entities;
/// <summary>
/// Ответственное лицо
/// </summary>
public class HeadUser
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Uuid { get; set; }
    
    /// <summary>
    /// Полное имя
    /// </summary>
    public string FullName { get; set; }
}