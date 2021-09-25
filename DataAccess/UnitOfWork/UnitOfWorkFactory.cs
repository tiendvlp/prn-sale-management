using DataAccess.repositories.Members;
using DataAccess.repositories.OrderDetails;
using DataAccess.repositories.Orders;
using DataAccess.repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWorkFactory
    {
        public UnitOfWork UnitOfWork { get { return new UnitOfWork(new Data.ApplicationDbContext()); } }
    }
}
