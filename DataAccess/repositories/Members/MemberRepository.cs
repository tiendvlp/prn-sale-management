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

        public IEnumerable<Member> GetWithFilters(string name, string id, string country, string city) {
            return _memberDao.GetWithFilters(name, id, country, city).ToList().OrderBy(m=>m.Name);
        }

        public void Add(string country, string city, string password, string email, string name, string companyName)
        {
            string id = System.Guid.NewGuid().ToString().Substring(0, 8);
            Member newMember = new Member(country, city, password, email, name, id, companyName);
            _memberDao.Add(newMember);
        }

        public IEnumerable<Member> GetAll()
        {
            return _memberDao.GetAll().ToList().OrderBy(m => m.Name);
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

        public void RemoveById(string id)
        {
            _memberDao.Remove(id);
        }

        public void Update(Member member)
        {
            Member updatedMember = _memberDao.Get(member.Id);

            updatedMember.Name = member.Name;
            updatedMember.Password = member.Password;
            updatedMember.Email = member.Email;
            updatedMember.Country = member.Country;
            updatedMember.City = member.City;
            updatedMember.CompanyName = member.CompanyName;
        }
    }
}
