using System.Linq.Expressions;

namespace AssistantManager.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T Get(string name);

        T Get(int id);

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);
    }
}
