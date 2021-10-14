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

        public OrderDetail Add(string orderId, string productId, double unitPrice, int quantity, float discount)
        {
            String id = System.Guid.NewGuid().ToString().Substring(0, 8);
            OrderDetail newOrderDetail = new OrderDetail(id, orderId, productId, unitPrice, quantity, discount);
            _orderDetailDao.Add(newOrderDetail);

            return newOrderDetail;
        }
    }
}
