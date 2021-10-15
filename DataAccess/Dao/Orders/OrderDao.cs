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
            IQueryable<Order> result = from order in _dbContext.Orders
                                       where
                                       order.OrderDate.Year >= startDate.Year &&
                                       order.OrderDate.Month >= startDate.Month &&
                                       order.OrderDate.Day >= startDate.Day
                                       &&
                                       order.OrderDate.Year <= endDate.Year &&
                                       order.OrderDate.Month <= endDate.Month &&
                                       order.OrderDate.Day <= endDate.Day
                                       select order;
            return result;
        }

        public void RemoveOrderContainsNoOrderDetails()
        {
            List<String> AllOrderId = (from orderDetails in _dbContext.OrderDetails select orderDetails.OrderId).ToList();
            _dbContext.Orders.RemoveRange(
                from order in _dbContext.Orders
                where
                !(AllOrderId
                .Contains(order.Id))
                select order);
        }
    }
}
