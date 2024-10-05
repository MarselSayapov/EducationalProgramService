using Domain.Entities;

namespace Domain.Interfaces;
/// <summary>
/// Интерфейс для реализации репозиториев
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T: class
{
    Task<IQueryable<T>> GetAllAsync();
    
    Task<T> GetAsync(Guid id);
    
    Task CreateAsync(T item);
    
    void Update(T item);
    
    Task DeleteAsync(Guid id);

}