using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;

namespace DataAccess.Dao.Members
{
    public interface IMemberDao : IDao<Member>
    {
        public Member getByEmail(String email);
        public IQueryable<Member> GetWithFilters(string name, string id, string country, string city);
    }
}
