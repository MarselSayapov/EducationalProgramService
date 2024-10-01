using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infastracted.Contexts;

public class ProgramContext
{
    /// <summary>
    /// Коллекция образовательных программ
    /// </summary>
    public DbSet<EducationalProgram> edPrograms => Set<EducationalProgram>();
}