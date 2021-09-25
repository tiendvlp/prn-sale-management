using System;
using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Dao.Members
{
    public interface IMemberDao : IDao<Member>
    {
        public Member getByEmail(String email);
    }
}
