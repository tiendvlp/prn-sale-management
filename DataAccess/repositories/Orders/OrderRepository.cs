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



    }
}
