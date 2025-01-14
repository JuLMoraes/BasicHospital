using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Core.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Base
{
    public abstract class BaseRepositoryEntity<T> : IBaseRepositoryEntity<T> where T : class
    {
        protected readonly DbContext _context;
        private List<object> _entities = new ();

        protected BaseRepositoryEntity(DbContext context)
        {
            _context = context;
        }

        //INSERT
        public virtual async Task Add(T entity, bool save = true)
        {
            try
            {
                await _context.AddAsync(entity);
                _entities.Add(entity);
                if (save)
                {
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
           
        }

        public virtual async Task Add(List<T> entities, bool save = true)
        {
            await _context.AddRangeAsync(entities);
            _entities.AddRange(entities);
            if (save)
            {
                await _context.SaveChangesAsync();
            }
        }

        //UPDATE
        public virtual async Task Alt(T entity, bool save = true)
        {
            _context.Update(entity);
            _entities.Add(entity);
            if (save)
            {
                await _context.SaveChangesAsync();
            }
        }
        public virtual async Task Alt(List<T> entities, bool save = true)
        {
            _context.Update(entities);
            _entities.AddRange(entities);
            if (save)
            {
                await _context.SaveChangesAsync();
            }
        }

        //SELECT 
        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.Where(where).ToListAsync();
        }
    }
}
