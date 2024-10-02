using Domain.Entities;
using Domain.Interfaces;

namespace Infastracted.Data;
/// <summary>
/// Репозиторий образовательных программ
/// </summary>
public class EducationalProgramRepository(ProgramDbContext context) : IRepository<EducationalProgram>
{
    public IEnumerable<EducationalProgram> GetAll()
    {
        return context.edPrograms;
    }

    public EducationalProgram Get(Guid id)
    {
        return context.edPrograms.Find(id);
    }

    public void Create(EducationalProgram item)
    {
        context.edPrograms.Add(item);
    }

    public void Update(EducationalProgram item)
    {
        context.edPrograms.Update(item);
    }

    public void Delete(Guid id)
    {
        EducationalProgram program = context.edPrograms.Find(id);
        if (program != null)
            context.edPrograms.Remove(program);
    }
}