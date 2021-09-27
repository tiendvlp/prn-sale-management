using System;
using DataAccess.Dao.Members;
using DataAccess.Dao.OrderDetails;
using DataAccess.Dao.Products;
using DataAccess.repositories.Categories;
using DataAccess.repositories.Members;
using DataAccess.repositories.OrderDetails;
using DataAccess.repositories.Orders;
using DataAccess.repositories.Products;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IMemberRepository MemberRepository { get; }

        void Save();

    }
}
