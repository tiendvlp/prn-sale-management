using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Dao
{
    public interface IDao<TDto> where TDto : class
    {
        TDto Get(String Id);

        IQueryable<TDto> GetAll(
            Expression<Func<TDto, bool>> filter = null,
            Func<IQueryable, IOrderedQueryable<TDto>> orderBy = null,
            string includeProperties = null
            );

        TDto GetFirstOrDefault(
            Expression<Func<TDto, bool>> filter = null,
            string includeProperties = null
            );

        void Add(TDto dto);
        void Remove(TDto dto);
        void Remove(String id);
        void RemoveRange(IEnumerable<TDto> dto);
    }
}
