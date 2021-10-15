using System;
using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.repositories.OrderDetails
{
    public interface IOrderDetailRepository
    {
        public OrderDetail Add(string orderId, string productId, double unitPrice, int quantity, float discount);
        List<OrderDetail> GetByOrderId(string id);
        void RemoveByOrderId(string id);
    }
}
