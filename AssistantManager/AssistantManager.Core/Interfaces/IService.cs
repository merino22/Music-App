using AssistantManager.Core.Models;
using System.Linq.Expressions;

namespace AssistantManager.Core.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> Get();

        Result<T> Get(string name);

        Result<T> Get(int id);

        Result<T> Add(T entity);

        Result<T> Update(T entity);

        Result<T> Delete(string name);
    }
}
