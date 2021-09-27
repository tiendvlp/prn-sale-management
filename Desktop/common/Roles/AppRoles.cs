using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.common.Roles
{
    public class AppRoles
    {
        public UserRole CurrentRole { get; set;}
        public bool IsAdmin { get { return CurrentRole is UserRole.Admin; } }

        public AppRoles( )
        {
          
        }
    }
}
