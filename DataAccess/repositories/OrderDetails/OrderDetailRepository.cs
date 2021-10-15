using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessObject;
using DataAccess.Dao.OrderDetails;
using DataAccess.UnitOfWork;

namespace DataAccess.repositories.OrderDetails
{
    public class OrderDetailRespository : IOrderDetailRepository
    {
        private IOrderDetailsDao _orderDetailDao;

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

        public List<OrderDetail> GetByOrderId(string id)
        {
            IQueryable<OrderDetail> queryResult = _orderDetailDao.GetAll (filter: orderDetail => orderDetail.OrderId.Equals(id));
            return queryResult.ToList();
        }

        public void RemoveByOrderId(string id)
        {
            _orderDetailDao.RemoveByOrderId(id);
        }

        public void RemoveByProductId(string id)
        {
            _orderDetailDao.RemoveByProductId(id);
        }
    }
}
