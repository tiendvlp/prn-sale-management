using System;
using DataAccess.Data;
using BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao.OrderDetails
{
    public class OrderDetailDao : Dao<Order>, IOrderDetailsDao
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDetailDao(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OrderDetail> getByOrderId(string orderId)
        {
            IQueryable<OrderDetail> result = (from x in _dbContext.OrderDetails where x.Id == orderId select x);
            return result.ToList();
        }
    }
}
