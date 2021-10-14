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
    public partial class FormCreateOrder : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        private List<Product> _boughtProducts;
        private UCOrderInfo OrderInfo;


        public FormCreateOrder(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole, List<Product> boughtProducts)
        {
            _serviceProvider = serviceProvider;
            _boughtProducts = boughtProducts;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();
            _setCategories();
            _initOrder();
        }

        private void _initOrder()
        {
            _initUcLayout();
            if (_appRole.IsAdmin)
            {

            } else
            {
                OrderInfo.SetProducts(_boughtProducts);
                Member m = (_appRole.CurrentRole as UserRole.Member).Info;
                OrderInfo.SetUserInfo(m.City,m.CompanyName, m.Country, m.Email);
            }
        }

        private void _initUcLayout ()
        {
            OrderInfo = new UCOrderInfo();
            mainLayoutContainer.Controls.Add(OrderInfo);
            OrderInfo.Dock = DockStyle.Fill;
        }

        private void _setCategories()
        {
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                var categories = work.CategoryRepository.GetAll();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void ucOrderInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
