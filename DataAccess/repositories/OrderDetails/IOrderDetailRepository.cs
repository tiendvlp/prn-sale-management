using System;
using BusinessObject;

namespace DataAccess.repositories.OrderDetails
{
    public interface IOrderDetailRepository
    {
        public OrderDetail Add(string orderId, string productId, double unitPrice, int quantity, float discount);

    }
}
