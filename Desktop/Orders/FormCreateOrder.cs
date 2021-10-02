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
        public FormCreateOrder(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole)
        {
            _serviceProvider = serviceProvider;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();

            _setCategories();
            _setWeightUnit();
        }

        private void _setCategories()
        {
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                var categories = work.CategoryRepository.GetAll();
                ucProductInfo.SetCategories(categories);
            }
        }

        private void _setWeightUnit()
        {
            ucProductInfo.SetWeightUnit(Enum.GetValues(typeof(WeightUnit)).Cast<WeightUnit>());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var productInfo = ucProductInfo.GetProductInput();

            if (productInfo != null)
            {
                var value = productInfo.Value;

                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    work.ProductRepository.Add(value.category.Id, value.name, value.weight, value.unit, value.quantity, value.price);
                    work.Save();
                }

                MessageBox.Show("Add product successfully !!", "Create product", MessageBoxButtons.OK);

                ucProductInfo.ClearInput();
            }

        }
    }
}
