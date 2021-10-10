using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Dao
{
    public class Dao<Entity> : IDao<Entity> where Entity : BusinessObject.Entity
    {
        protected readonly ApplicationDbContext _dbContext;
        internal List<Entity> dbSet;

        public Dao(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.List<Entity>();
        }

        public void Add(Entity dto)
        {
            dbSet.Add(dto);
        }

        public Entity Get(string Id)
        {
            return dbSet.Find(x => x.Id == Id);
        }

        public IEnumerable<Entity> GetAll(Func<Entity, bool> filter = null, Func<IEnumerable<Entity>, IOrderedEnumerable<Entity>> orderBy = null)
        {
            IEnumerable<Entity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;

        }

        public Entity GetFirstOrDefault(Func<Entity, bool> filter = null, Func<IEnumerable<Entity>, IOrderedEnumerable<Entity>> orderBy = null)
        {
            IEnumerable<Entity> query = dbSet;

            if (filter != null)
            {
                query.Where(filter);
            }

            return query.FirstOrDefault();

        }

        public void Remove(Entity dto)
        {
            dbSet.Remove(dto);
        }

        public void Remove(string id)
        {
            Entity deletedDto = dbSet.Find(entity => entity.Id == id);
            if (deletedDto != null)
            {
                dbSet.Remove(deletedDto);
            }
        }

    }
}
