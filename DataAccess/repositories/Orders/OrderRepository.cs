using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;
using DataAccess.Dao.Orders;

namespace DataAccess.repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderDao _orderDao;

        public OrderRepository(OrderDao orderDao)
        {
            _orderDao = orderDao;
        }

        public Order Add(string memberId, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, double freight)
        {
            String id = System.Guid.NewGuid().ToString().Substring(0, 8);
            Order newOrder = new Order(id, memberId, orderDate, requiredDate, shippedDate, freight);

            _orderDao.Add(newOrder);

            return newOrder;
        }

        public List<Order> GetWithFilter(DateTime startDate, DateTime endDate)
        {
            IQueryable<Order> queryResult = _orderDao.GetWithFilter(startDate, endDate);

            List<Order> result = queryResult.OrderByDescending(o => o.OrderDate).ToList();

            return result;
        }

        public void RemoveById(string id)
        {
            _orderDao.Remove(id);
        }

        public void RemoveByMemberId(string id)
        {
            _orderDao.RemoveByMemberId(id);
        }

        public void RemoveOrderContainsNoOrderDetails()
        {
            _orderDao.RemoveOrderContainsNoOrderDetails();
        }

        public void Update(string orderId, string memberId, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, double freight)
        {
           Order target = _orderDao.Get(orderId);
            target.MemberId = memberId;
            target.OrderDate = orderDate;
            target.RequiredDate = requiredDate;
            target.ShippedDate = shippedDate;
            target.Freight = freight;
        }
    }
}
