using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.common.Roles
{
    public class UserRole
    {
        public class Member : UserRole
        {
            public Member(BusinessObject.Member info)
            {
                Info = info;
            }

            public BusinessObject.Member Info { get; }
        }

        public class Admin : UserRole
        {
        }
    }
}
