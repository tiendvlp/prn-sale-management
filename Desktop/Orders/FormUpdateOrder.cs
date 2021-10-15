using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common;
using Desktop.common.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Orders
{
    public partial class FormUpdateOrder : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        private List<Product> _boughtProducts = new List<Product>();
        private Order CurrentOrder;
        private UCOrderInfo OrderInfo;

        public FormUpdateOrder(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole, Order order)
        {
            _serviceProvider = serviceProvider;
            CurrentOrder = order;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();
            _loadProducts();
            _initOrder();
        }

        private void _loadProducts ()
        {
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                List<OrderDetail> orderDetail = work.OrderDetailRepository.GetByOrderId(CurrentOrder.Id);

                orderDetail.ForEach(detail => {
                    _boughtProducts.Add(detail.Product);
                });
            }
        }

        private void _initOrder()
        {
          
            _initUcLayout();
            OrderInfo.SetProducts(_boughtProducts);
            OrderInfo.CallBack = _onUcCEvent;
            OrderInfo.SetOrderInfo(CurrentOrder.OrderDate, CurrentOrder.ShippedDate, CurrentOrder.RequiredDate, CurrentOrder.Freight);
            OrderInfo.SetMemberInfo(CurrentOrder.Member.Email);
        }

        private void _onUcCEvent (UCOrderInfo.EVENT_TYPE type, Object data)
        {
            if (type == UCOrderInfo.EVENT_TYPE.CANCEL)
            {
                this.Close();
            }
        }
        private void _initUcLayout ()
        {
            OrderInfo = new UCOrderInfo();
            mainLayoutContainer.Controls.Add(OrderInfo);
            OrderInfo.Dock = DockStyle.Fill;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var data = OrderInfo.getData();

            // update order

            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                Member member = work.MemberRepository.GetByEmail(data.memberEmail);

                if (member == null)
                {
                    MessageBox.Show("Your member does not exist", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                work.OrderRepository.Update(CurrentOrder.Id, member.Id, CurrentOrder.OrderDate, data.RequiredDate, data.ShippedDate, data.freight);
                
                work.OrderDetailRepository.RemoveByOrderId(CurrentOrder.Id);

                data.Products.ForEach(product => {
                    work.OrderDetailRepository.Add(CurrentOrder.Id, product.Id, product.Price, data.Quantity[product.Id], 1);
                });

                work.Save();
            }

            MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ucOrderInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
