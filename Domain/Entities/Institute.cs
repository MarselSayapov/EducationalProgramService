using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
/// <summary>
/// Институт
/// </summary>
public class Institute
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
}