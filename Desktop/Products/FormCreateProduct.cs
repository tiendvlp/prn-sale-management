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

namespace Desktop.Products
{
    public partial class FormCreateProduct : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        public FormCreateProduct(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole)
        {
            _serviceProvider = serviceProvider;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();

            _setCategories();
            _setWeightUnit();
        }

        private void _setCategories ()
        {
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                work.CategoryRepository.GetAll();
            }
        }

        private void _setWeightUnit ()
        {
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {

            }
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
                 //   work.ProductRepository.Add(value.category);

                    work.Save();
                }
            }

        }
    }
}
