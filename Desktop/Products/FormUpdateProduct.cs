using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common;
using Desktop.common.Roles;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class FormUpdateProduct : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        private Product _product;
        public FormUpdateProduct(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole,Product updatedProduct)
        {
            _product = updatedProduct;
            _serviceProvider = serviceProvider;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();

            _setCategories();
            _setWeightUnit();
            _setUpdateProduct();
        }

        private void _setUpdateProduct ()
        {
            ucProductInfo.SetContent(_product);
        }

        private void _setCategories ()
        {
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                var categories = work.CategoryRepository.GetAll();
                ucProductInfo.SetCategories(categories);
            }
        }

        private void _setWeightUnit ()
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
                    _product.SetCategory(value.category);
                    _product.Name = value.name;
                    _product.Price = value.price;
                    _product.setWeightUnit(value.unit);
                    _product.Weight = value.weight;
                    _product.Quantity = value.quantity;

                    work.ProductRepository.Update(_product);
                    work.Save();
                }
                    using (var work = _unitOfWorkFactory.UnitOfWork)
                    {
                        _product = work.ProductRepository.GetById(_product.Id);
                        _setUpdateProduct();
                    }

                    MessageBox.Show("Update product successfully !!", "Update product", MessageBoxButtons.OK);
                } else
                {
                    MessageBox.Show("Update product failed !!", "Update product", MessageBoxButtons.OK);
                }
            }
    }
}
