using System;
using DataAccess.Data;
using BusinessObject;
using System.Linq;
using System.Collections.Generic;
using NHibernate.Linq;

namespace DataAccess.Dao.Members
{
    public class MemberDao : Dao<Member>, IMemberDao
    {
        private readonly ApplicationDbContext _dbContext;

        public MemberDao(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Member getByEmail(string email)
        {
            IQueryable<Member> result = from mem in _dbContext.Members where mem.Email == email select mem;
            return result.FirstOrDefault();
        }

        public IQueryable<Member> GetWithFilters(string name, string id, string country, string city)
        {
            IQueryable<Member> result = from mem in _dbContext.Members select mem;

            if (!String.IsNullOrWhiteSpace(name))
            {
                result = from mem in result where mem.Name.ToLower().Contains(name.ToLower()) select mem;
            }
            if (!String.IsNullOrWhiteSpace(id))
            {
                result = from mem in result where mem.Id == id select mem;
            }
            if (!String.IsNullOrWhiteSpace(country))
            {
                result = from mem in result where mem.Country.ToLower().Contains(country.ToLower()) select mem;
            }
            if (!String.IsNullOrWhiteSpace(city))
            {
                result = from mem in result where mem.City.ToLower().Contains(city.ToLower()) select mem;
            }

            return result;
        }
    }
}
