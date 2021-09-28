using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Dao
{
    public class Dao<TDto> : IDao<TDto> where TDto : class
    {
        private readonly ApplicationDbContext _dbContext;
        internal DbSet<TDto> dbSet;

        public Dao(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<TDto>();
        }

        public void Add(TDto dto)
        {
            dbSet.Add(dto);
        }

        public TDto Get(string Id)
        {
            return dbSet.Find(Id);
        }

        public IQueryable<TDto> GetAll(Expression<Func<TDto, bool>> filter = null, Func<IQueryable, IOrderedQueryable<TDto>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TDto> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includedProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includedProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;

        }

        public TDto GetFirstOrDefault(Expression<Func<TDto, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TDto> query = dbSet;

            if (filter != null)
            {
                query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includedProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includedProp);
                }
            }

            return query.FirstOrDefault();

        }

        public void Remove(TDto dto)
        {
            dbSet.Remove(dto);
        }

        public void Remove(string id)
        {
            TDto deletedDto = dbSet.Find(id);
            if (deletedDto != null)
            {
                dbSet.Remove(deletedDto);
            }
        }

        public void RemoveRange(IEnumerable<TDto> dto)
        {
            dbSet.RemoveRange(dto);
        }
    }
}
