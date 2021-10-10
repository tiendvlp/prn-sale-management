using System;
using BusinessObject;
using System.Linq;
using System.Collections.Generic;
using NHibernate.Linq;
using DataAccess.Data;

namespace DataAccess.Dao.Members
{
    public class MemberDao : Dao<Member>, IMemberDao
    {
        public MemberDao() : base(ApplicationDbContext.Instance)
        {
        }

        public Member getByEmail(string email)
        {
            IEnumerable<Member> result = from mem in _dbContext.List<Member>() where mem.Email == email select mem;
            return result.FirstOrDefault();
        }

        public IEnumerable<Member> GetWithFilters(string name, string id, string country, string city)
        {
            IEnumerable<Member> result = from mem in _dbContext.List<Member>() select mem;

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
