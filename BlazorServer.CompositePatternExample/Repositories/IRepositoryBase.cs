using BlazorServer.CompositePatternExample.Domain.Models;

namespace BlazorServer.CompositePatternExample.Repositories
{
    public interface IRepositoryBase<T> where T : ModelBase
    {
        T Add(T entity);

        bool Delete(T entity);

        bool DeleteById(int entityId);

        IEnumerable<T> Filter(Func<T, bool> predicate);

        IEnumerable<T> GetAll();

        T? GetById(int id);

        T Update(T entity);
    }
}
