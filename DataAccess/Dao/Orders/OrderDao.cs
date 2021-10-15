using System;
using DataAccess.Data;
using BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dao.Orders
{
    public class OrderDao : Dao<Order>, IOrderDao
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDao(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Order> GetWithFilter(DateTime startDate, DateTime endDate)
        {
            IQueryable<Order> result = from order in _dbContext.Orders where order.OrderDate >= startDate && order.OrderDate <= endDate select order;

            return result;
        }

    }
}
