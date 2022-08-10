using Microsoft.EntityFrameworkCore;

namespace CorePrac.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<DbSet<TEntity>, IQueryable<TEntity>> func = null);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IList<TEntity> Get(Func<DbSet<TEntity>, IQueryable<TEntity>> func = null);
        TEntity GetById(long id);
        void Insert(TEntity entity);
        TEntity InsertAndGet(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Remove(TEntity entity);
        bool IsExist(long id);
        void SaveChanges();

        void UpdateAsNoTracking(TEntity entity);
    }
}
