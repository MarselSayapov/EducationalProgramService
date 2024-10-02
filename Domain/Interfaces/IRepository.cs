namespace Domain.Interfaces;
/// <summary>
/// Интерфейс для реализации репозиториев
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll();
    
    T Get(Guid id);
    
    void Create(T item);
    
    void Update(T item);
    
    void Delete(Guid id);

}