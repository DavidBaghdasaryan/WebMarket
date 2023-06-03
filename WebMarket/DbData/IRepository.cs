using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WebMarket.DbData
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        void RemoveRange(IEnumerable<T> items);
        void Save();
    }
}
