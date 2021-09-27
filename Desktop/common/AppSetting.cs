using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.common
{
    public class Admin
    {
        public String Email { get; set; }
        public String Password { get; set; }

    }
    public class AppSetting
    {
        public Admin[] Admins { get; set; }
        public AppSetting()
        {
            
        }
    }
}
