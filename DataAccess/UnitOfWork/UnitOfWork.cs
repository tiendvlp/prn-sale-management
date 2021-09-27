using DataAccess.Dao.Members;
using DataAccess.Dao.OrderDetails;
using DataAccess.Dao.Orders;
using DataAccess.Dao.Categories;
using DataAccess.Dao.Products;
using DataAccess.Data;
using DataAccess.repositories.Categories;
using DataAccess.repositories.Members;
using DataAccess.repositories.OrderDetails;
using DataAccess.repositories.Orders;
using DataAccess.repositories.Products;
using System;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IMemberRepository _memberRepository;

        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            _orderRepository = new OrderRepository(new OrderDao(_db));
            _orderDetailRepository = new OrderDetailRespository(new OrderDetailDao(db));
            _productRepository = new ProductRepository(new ProductDao(db));
            _categoryRepository = new CategoryRepository(new CategoryDao(db));
            _memberRepository = new MemberRepository(new MemberDao(db));
        }

        public IOrderRepository OrderRepository => _orderRepository;

        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;

        public IProductRepository ProductRepository => _productRepository;

        public IMemberRepository MemberRepository => _memberRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public void Dispose()
        {
            Console.WriteLine("Unit of work has been dispose");
            _db.Dispose();
        }

        public void Save()
        {
            Console.WriteLine("Unit of work has been saved");
            _db.SaveChanges();
        }
    }
}
