﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infastracted;

/// <summary>
/// Контекст
/// </summary>
public class ApplicationDbContext
{
    /// <summary>
    /// Коллекция образовательных программ
    /// </summary>
    public DbSet<EducationalProgram> edPrograms { get; set; }
    
    /// <summary>
    /// Коллекция образовательных модулей
    /// </summary>
    public DbSet<EducationalModule> edModules { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }


}