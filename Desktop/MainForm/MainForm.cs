using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.Products;
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
using Desktop.common.MessageBoxHelper;

namespace Desktop.MainForm
{
    public partial class MainForm : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;

        public MainForm(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {

        }

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {

            UCProducts uc = null;
            if (!tbnContainer.Controls.ContainsKey(nameof(UCProducts)))
            {
                uc = new UCProducts(UCProducts.ADMIN_MODE);
                uc.Dock = DockStyle.Fill;
                tbnContainer.Controls.Add(uc);
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    uc.AddProduct(work.ProductRepository.GetAll().ToList());
                }
            }

            uc = (UCProducts)tbnContainer.Controls[nameof(UCProducts)];
            uc.CallBack = OnActionOccursProductList;
            uc.TaskBarActionCallBack = OnTaskBarActionCallBack;
            uc.BringToFront();
        }

        private void OnTaskBarActionCallBack(UCProducts.TASK_BAR_EVENT e, List<Product> product)
        {
            if (e == UCProducts.TASK_BAR_EVENT.CREATE)
            {
                FormCreateProduct createProductForm = serviceProvider.GetRequiredService<FormCreateProduct>();
                createProductForm.ShowDialog();
                _reloadProduct();
                return;
            }

            if (e == UCProducts.TASK_BAR_EVENT.DELETE)
            {
                DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to delete " + product.Count + " products", "Confirm");

                if (result == DialogResult.Yes)
                {
                    // delete all selected products
                    using (var work = _unitOfWorkFactory.UnitOfWork)
                    {
                        product.ForEach(p => work.ProductRepository.RemoveById(p.Id));

                        work.Save();
                    }

                    _reloadProduct();
                    return;
                }
            }

        }

        private void _reloadProduct ()
        {
            UCProducts uc = (UCProducts)tbnContainer.Controls[nameof(UCProducts)];
            if (uc != null)
            {
                uc.ClearProducts();
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    uc.AddProduct(work.ProductRepository.GetAll().ToList());
                }
            }
        }

        private void OnActionOccursProductList (UCProducts.EVENT e, Product product )
        {
            if (e == UCProducts.EVENT.DELETE)
            {
                DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to delete " + product.Name, "Confirm");

                if (result == DialogResult.Yes)
                {
                    using (var work = _unitOfWorkFactory.UnitOfWork)
                    {
                        work.ProductRepository.RemoveById(product.Id);
                        work.Save();
                    }

                    _reloadProduct();
                }
            }
            if (e == UCProducts.EVENT.UPDATE)
            {
                FormUpdateProduct updateProductForm = ActivatorUtilities.CreateInstance<FormUpdateProduct>(serviceProvider, product);
                updateProductForm.ShowDialog();
                _reloadProduct();
            }
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {

        }
    }
}
