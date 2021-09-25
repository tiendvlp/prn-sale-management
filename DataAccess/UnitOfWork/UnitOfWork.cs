using DataAccess.Dao.Members;
using DataAccess.Dao.OrderDetails;
using DataAccess.Dao.Orders;
using DataAccess.Dao.Products;
using DataAccess.Data;
using DataAccess.repositories.Members;
using DataAccess.repositories.OrderDetails;
using DataAccess.repositories.Orders;
using DataAccess.repositories.Products;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IProductRepository _productRepository;
        private IMemberRepository _memberRepository;

        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            _orderRepository = new OrderRepository(new OrderDao(_db));
            _orderDetailRepository = new OrderDetailRespository(new OrderDetailDao(db));
            _productRepository = new ProductRepository(new ProductDao(db));
            _memberRepository = new MemberRepository(new MemberDao(db));
        }

        public IOrderRepository OrderRepository => _orderRepository;

        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;

        public IProductRepository ProductRepository => _productRepository;

        public IMemberRepository MemberRepository => _memberRepository;

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
