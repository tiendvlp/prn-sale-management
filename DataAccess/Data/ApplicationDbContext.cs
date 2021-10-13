using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext
    {
        private List<Member> members = new List<Member> {
            new Member("Việt Nam","Ho Chi Minh", "123123", "tiendvlp@gmail.com", "Dang Minh Tien", "13213", "Devlogs"),
            new Member("Việt Nam","Nghe An", "123123", "minhthuan@gmail.com", "Tran Minh Thuan","75213", "Facebook"),
            new Member("USA","Cali", "123123", "ngoc@gmail.com", "Phan Thieu Ngoc","47213", "Google"),
            new Member("USA","New York", "123123", "khang@gmail.com", "Nguyen Van Khang","99213", "Viettel"),
            new Member("Japan","Tokyo", "123123", "nhu@gmail.com", "Lam Tam Nhu","9213", "TinhTe"),
        };

        private static ApplicationDbContext instance = null;
        private static readonly object instanceLook = new object();

        private ApplicationDbContext()
        {

        }

        public static ApplicationDbContext Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new ApplicationDbContext();
                    }
                    return instance;
                }
            }
        }

        public List<T> List<T> ()
        {
            Type listType = typeof(T);
            if (listType == typeof(Member))
            {
                return members as List<T>; 
            }

            throw new Exception("Invalid type of T");
        }

    }
}
