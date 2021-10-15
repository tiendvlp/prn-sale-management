using System;
using System.Collections;
using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Dao.OrderDetails
{
    public interface IOrderDetailsDao : IDao<OrderDetail>
    {
        public IEnumerable<OrderDetail> getByOrderId(String orderId);
        void RemoveByOrderId(string id);
    }
}
