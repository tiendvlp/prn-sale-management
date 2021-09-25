using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;
using DataAccess.Dao.Members;
using DataAccess.UnitOfWork;

namespace DataAccess.repositories.Members
{
    public class MemberRepository : IMemberRepository
    {
        private IMemberDao _memberDao;

        public MemberRepository(MemberDao memberDao)
        {
            _memberDao = memberDao;
        }

        public void Add(Member member)
        {
            _memberDao.Add(member);
        }

        public IEnumerable<Member> GetAll()
        {
            return _memberDao.GetAll();
        }

        public Member GetByEmail(string email)
        {
            return _memberDao.getByEmail(email);
        }

        public Member GetById(string id)
        {
            return _memberDao.Get(id);
        }

        public void Remove(Member member)
        {
            _memberDao.Remove(member);
        }
    }
}
