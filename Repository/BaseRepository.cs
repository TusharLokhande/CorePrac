using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorePrac.Models;

namespace CorePrac.Repository
{
    public partial class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        IndoContext _context;
        private DbSet<TEntity> entities;
        DbSet<TEntity> IRepository<TEntity>.Table => entities;

        public BaseRepository(IndoContext context)
        {
            this._context = context;
            entities = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return entities.AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Get List of data using linq query from underlaing table
        /// </summary>
        /// <param name="func">LINQ Function to select entries</param>
        /// <returns>List of records</returns>
        public virtual IList<TEntity> Get(Func<DbSet<TEntity>, IQueryable<TEntity>> func = null)
        {
            var query = func != null ? func(entities) : entities;

            return query.ToList();
        }

        /// <summary>
        /// Get data by ID
        /// </summary>
        /// <param name="id">Underlayig table ID column</param>
        /// <returns>Single record by Id</returns>
        public TEntity GetById(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Insert a single row in underlaying table 
        /// </summary>
        /// <param name="entity"> Record entity</param>
        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateAsNoTracking(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }


            _context.ChangeTracker.Clear();
            _context.Update(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Insert and getback a single row in underlaying table 
        /// </summary>
        /// <param name="entity">Record entity</param>
        /// <returns>After Inster record from table </returns>
        public TEntity InsertAndGet(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }



            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }
        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public bool IsExist(long id)
        {
            return entities.Any(i => i.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Func<DbSet<TEntity>, IQueryable<TEntity>> func = null)
        {
            var query = func != null ? func(entities) : entities;

            return query.ToList();
        }
    }
}
