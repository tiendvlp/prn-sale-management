using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Dao
{
    public interface IDao<Entity> where Entity : BusinessObject.Entity
    {
        Entity Get(String Id);

        IEnumerable<Entity> GetAll(
            Func<Entity, bool> filter = null,
            Func<IEnumerable<Entity>, IOrderedEnumerable<Entity>> orderBy = null
            );

        Entity GetFirstOrDefault(
             Func<Entity, bool> filter = null,
            Func<IEnumerable<Entity>, IOrderedEnumerable<Entity>> orderBy = null
            );

        void Add(Entity dto);
        void Remove(Entity dto);
        void Remove(String id);
    }
}
