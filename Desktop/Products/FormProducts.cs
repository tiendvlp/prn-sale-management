using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common.MessageBoxHelper;
using Desktop.common.Roles;
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

namespace Desktop.Products
{
    public partial class FormProducts : Form
    {
        public static int ADMIN_MODE = 1;
        public static int MEMBER_MODE = 2;
        private int _mode;
        private ColumnHeader ProductNameColumn = new ColumnHeader("Name") { Text = "Name" };
        private ColumnHeader ProductPriceColumn = new ColumnHeader("Price") { Text = "Price" };
        private ColumnHeader ProductCategoryColumn = new ColumnHeader("Category") { Text = "Category" };
        private ColumnHeader ProducWeightColumn = new ColumnHeader("Weight") { Text = "Weight" };
        private ColumnHeader ProductQuantityColumn = new ColumnHeader("Quantity") { Text = "Quantity" };


        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;
        private Form _activeForm;
        public FormProducts(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, AppRoles appRoles)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            if (appRoles.IsAdmin)
            {
                _mode = ADMIN_MODE;
            } else
            {
                _mode = MEMBER_MODE;
            }

            InitializeComponent();
            _initListView();
        }

        public FormProducts(int mode)
        {
            if (mode != ADMIN_MODE && mode != MEMBER_MODE)
            {
                throw new Exception("Your mode is invalid: " + mode);
            }
            _mode = mode;
            InitializeComponent();
            _initListView();
        }


        private void _initListView()
        {
            lvProduct.View = View.Details;
            lvProduct.CheckBoxes = true;
            lvProduct.FullRowSelect = true;
            lvProduct.GridLines = true;
            lvProduct.Columns.Add(ProductNameColumn);
            lvProduct.Columns.Add(ProductPriceColumn);
            lvProduct.Columns.Add(ProductCategoryColumn);
            lvProduct.Columns.Add(ProductQuantityColumn);
            lvProduct.Columns.Add(ProducWeightColumn);

            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                AddProduct(work.ProductRepository.GetAll().ToList());
            }
        }

        public void AddProduct(List<Product> product)
        {
            product.ForEach(product => AddProduct(product));
        }

        public void AddProduct(Product product)
        {
            var newItem = new ListViewItem();
            newItem.Tag = product;
            newItem.Text = product.Name;
            newItem.SubItems.Add
                (new ListViewItem.ListViewSubItem()
                {
                    Text = product.Price + ""
                });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = product.Category.Name
            });

            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = product.Weight + " " + product.Unit
            });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = product.Quantity + ""
            });

            lvProduct.Items.Add(newItem);
        }

        internal void ClearProducts()
        {
            lvProduct.Items.Clear();
        }

        private void lvProducts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvProduct.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    if (_mode == ADMIN_MODE)
                    {
                        menuStripAdmin.Show(Cursor.Position);
                    }
                    else
                    {
                        menuStripMember.Show(Cursor.Position);
                    }
                }
            }
        }

        private void OnMemberMenu_click(object sender, EventArgs e)
        {
            var focusedItem = lvProduct.FocusedItem;
            if (focusedItem != null)
            {
                Product focusedProduct = (Product)focusedItem.Tag;
                string eventName = (sender as ToolStripItem).Text;
                if (eventName == "Buy")
                {
                    // TODO: Implement buy here
                    return;
                }
            }
        }

        private void OnAdminMenu_click(object sender, EventArgs e)
        {
            var focusedItem = lvProduct.FocusedItem;
            if (focusedItem != null)
            {
                Product focusedProduct = (Product)focusedItem.Tag;

                string eventName = (sender as ToolStripItem).Text;
                if (eventName == "Delete")
                {
                    DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to delete " + focusedProduct.Name, "Confirm");

                    if (result == DialogResult.Yes)
                    {
                        using (var work = _unitOfWorkFactory.UnitOfWork)
                        {
                            work.ProductRepository.RemoveById(focusedProduct.Id);
                            work.Save();
                        }

                        _reloadProduct();
                    }
                }
                if (eventName == "Update")
                {
                    FormUpdateProduct updateProductForm = ActivatorUtilities.CreateInstance<FormUpdateProduct>(serviceProvider, focusedProduct);
                    updateProductForm.ShowDialog();
                    _reloadProduct();
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<Product> selectedProduct = new List<Product>();

            for (int i = 0; i < lvProduct.CheckedItems.Count; i++)
            {
                Console.WriteLine("hihi selected");
                var item = lvProduct.CheckedItems[i];
                selectedProduct.Add((Product)item.Tag);
            }
            DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to delete " + selectedProduct.Count + " products", "Confirm");

            if (result == DialogResult.Yes)
            {
                // delete all selected products
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    selectedProduct.ForEach(p => work.ProductRepository.RemoveById(p.Id));

                    work.Save();
                }

                _reloadProduct();
                return;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<Product> selectedProduct = new List<Product>();
            for (int i = 0; i < lvProduct.SelectedItems.Count; i++)
            {
                var item = lvProduct.SelectedItems[i];
                selectedProduct.Add((Product)item.Tag);
            }
            FormCreateProduct createProductForm = serviceProvider.GetRequiredService<FormCreateProduct>();
            createProductForm.ShowDialog();
            _reloadProduct();
        }

        private void _reloadProduct()
        {
            ClearProducts();
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    AddProduct(work.ProductRepository.GetAll().ToList());
                }
            }
       
    }
}
