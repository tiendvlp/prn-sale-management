using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;

namespace DataAccess.repositories.Members
{
    public interface IMemberRepository
    {
        public void Add(string country, string city, string password, string email, string name, string companyName);
        public void Remove(Member member);
        public Member GetById(String id);
        public Member GetByEmail(String email);
        public IEnumerable<Member> GetAll();
        void Update(Member member);
        public IEnumerable<Member> GetWithFilters(string name, string id, string country, string city);
        void RemoveById(string id);
    }
}
