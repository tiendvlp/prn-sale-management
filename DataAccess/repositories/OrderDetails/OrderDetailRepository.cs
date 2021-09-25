using System;
using BusinessObject;
using DataAccess.Dao.OrderDetails;
using DataAccess.UnitOfWork;

namespace DataAccess.repositories.OrderDetails
{
    public class OrderDetailRespository : IOrderDetailRepository
    {
        private OrderDetailDao _orderDetailDao;

        public OrderDetailRespository(OrderDetailDao orderDetailDao)
        {
            _orderDetailDao = orderDetailDao;
        }

    }
}
