using System;

namespace Domain.Entities;
/// <summary>
/// Институт
/// </summary>
public class Institute
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Uuid { get; set; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; set; }
}