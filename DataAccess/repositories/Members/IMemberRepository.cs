using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;

namespace DataAccess.repositories.Members
{
    public interface IMemberRepository
    {
        public void Add(Member member);
        public void Remove(Member member);
        public Member GetById(String id);
        public Member GetByEmail(String email);
        public IEnumerable<Member> GetAll();
    }
}
