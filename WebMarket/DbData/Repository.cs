using Microsoft.EntityFrameworkCore;
using WebMarket.Models;

namespace WebMarket.DbData
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MarketDbContext _dbContext;
        internal DbSet<T> dbSet;
        public Repository(MarketDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
            
        }
        public void Add(T item)
        {
            _dbContext.Add(item);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }
        public void Update(T item)
        {
            dbSet.Update(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void RemoveRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }
        public List<Product> ProductList()
        {
            return _dbContext.Products.ToList();
        }
    }
}
