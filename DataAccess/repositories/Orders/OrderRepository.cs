using System;
using BusinessObject;
using DataAccess.Dao.Orders;

namespace DataAccess.repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDao _orderDao;

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
    }
}
