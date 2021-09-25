using System;
using DataAccess.Data;
using BusinessObject;
using System.Linq;

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
    }
}
