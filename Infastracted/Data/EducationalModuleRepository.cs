using Domain.Entities;
using Domain.Interfaces;

namespace Infastracted.Data;
/// <summary>
/// Репозиторий модулей
/// </summary>
public class EducationalModuleRepository(ProgramDbContext context) : IRepository<EducationalModule>
{
    public IEnumerable<EducationalModule> GetAll()
    {
        return context.edModules;
    }

    public EducationalModule Get(Guid id)
    {
        return context.edModules.Find(id);
    }

    public void Create(EducationalModule item)
    {
        context.edModules.Add(item);
    }

    public void Update(EducationalModule item)
    {
        context.edModules.Update(item);
    }

    public void Delete(Guid id)
    {
        EducationalModule module = context.edModules.Find(id);
        if (module != null)
        {
            context.edModules.Remove(module);
        }
    }
}