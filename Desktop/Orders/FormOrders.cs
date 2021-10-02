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
using Desktop.common.MessageBoxHelper;

namespace Desktop.Orders
{
    public partial class FormOrders : Form
    {
        public static int ADMIN_MODE = 1;
        public static int MEMBER_MODE = 2;
        private int _mode;
        private ColumnHeader ProductIdColumn = new ColumnHeader("Id") { Text = "Id" };
        private ColumnHeader ProductNameColumn = new ColumnHeader("Name") { Text = "Name" };
        private ColumnHeader ProductPriceColumn = new ColumnHeader("Price") { Text = "Price" };
        private ColumnHeader ProductCategoryColumn = new ColumnHeader("Category") { Text = "Category" };
        private ColumnHeader ProducWeightColumn = new ColumnHeader("Weight") { Text = "Weight" };
        private ColumnHeader ProductUnitColumn = new ColumnHeader("Unit") { Text = "Unit" };
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;

        private static (string id, string name, int unitMax, int unitMin, double priceMax, double priceMin) Filters = ("", "", 1000, 0, 1000, 0);

        public FormProducts(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, AppRoles appRoles)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            if (appRoles.IsAdmin)
            {
                _mode = ADMIN_MODE;
            }
            else
            {
                _mode = MEMBER_MODE;
            }

            InitializeComponent();
            _initListView();
            _initLayoutFilter();
            _reloadProduct();
            _setupLayoutDependOnRole();
        }

        private void _setupLayoutDependOnRole()
        {
            if (_mode == ADMIN_MODE)
            {
                btnCreate.Enabled = true;
                btnCreate.Visible = true;
                btnDelete.Visible = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
                btnCreate.Visible = false;
                btnDelete.Visible = false;
                btnDelete.Enabled = false;
            }
        }

        private void _initLayoutFilter()
        {
            txtPriceMax.Text = Filters.priceMax + "";
            txtPriceMin.Text = Filters.priceMin + "";
            txtUnitMax.Text = Filters.unitMax + "";
            txtUnitMin.Text = Filters.unitMin + "";

            chkPriceFilter.Checked = true;
            chkUnitFilter.Checked = true;

            txtPriceMax.TextChanged += new System.EventHandler(this.onPriceTextChanged);
            txtPriceMin.TextChanged += new System.EventHandler(this.onPriceTextChanged);

            txtUnitMax.TextChanged += new System.EventHandler(this.onUnitTextChanged);
            txtUnitMin.TextChanged += new System.EventHandler(this.onUnitTextChanged);
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
            _reloadProduct();
        }


        private void _initListView()
        {
            lvProduct.View = View.Details;
            lvProduct.CheckBoxes = true;
            lvProduct.FullRowSelect = true;
            lvProduct.GridLines = true;
            lvProduct.Columns.Add(ProductIdColumn);
            lvProduct.Columns.Add(ProductNameColumn);
            lvProduct.Columns.Add(ProductPriceColumn);
            lvProduct.Columns.Add(ProductCategoryColumn);
            lvProduct.Columns.Add(ProductUnitColumn);
            lvProduct.Columns.Add(ProducWeightColumn);

            ProductIdColumn.Width = 100;
            ProductNameColumn.Width = 130;
            ProductPriceColumn.Width = 80;
            ProductCategoryColumn.Width = 100;
            ProductUnitColumn.Width = 80;
            ProducWeightColumn.Width = 90;

        }

        public void AddProduct(List<Product> product)
        {
            product.ForEach(product => AddProduct(product));
        }

        public void AddProduct(Product product)
        {
            var newItem = new ListViewItem();
            newItem.Tag = product;
            newItem.Text = product.Id;
            newItem.SubItems.Add
               (new ListViewItem.ListViewSubItem()
               {
                   Text = product.Name + ""
               });
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
                    DialogResult result = this.ShowYesNoInfoMessageBox("Are you sure to buy: " + focusedProduct.Name);

                    if (result.Equals(DialogResult.Yes))
                    {
                        _buyProduct(focusedProduct);
                    }
                    return;
                }
            }
        }

        private void _buyProduct(Product product)
        {

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
            int unitMax = Filters.unitMax;
            int unitMin = Filters.unitMin;
            double priceMax = Filters.priceMax;
            double priceMin = Filters.priceMin;

            if (!chkUnitFilter.Checked)
            {
                unitMax = -1;
                unitMin = -1;
            }

            if (!chkPriceFilter.Checked)
            {
                priceMax = -1;
                priceMin = -1;
            }

            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                AddProduct(work.ProductRepository.GetWIthFilter(Filters.id, Filters.name, unitMax, unitMin, priceMax, priceMin).ToList());
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filters.name = txtProductName.Text;
            Filters.id = txtProductId.Text;
            Filters.priceMax = Double.Parse(txtPriceMax.Text);
            Filters.priceMin = Double.Parse(txtPriceMin.Text);
            Filters.unitMax = int.Parse(txtUnitMax.Text);
            Filters.unitMin = int.Parse(txtUnitMin.Text);
            _reloadProduct();
        }

        private void onPriceKeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void onUnitKeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }


        private void onPriceTextChanged(object sender, EventArgs e)
        {
            if (sender == txtPriceMax && String.IsNullOrWhiteSpace(txtPriceMax.Text))
            {
                return;
            }
            if (sender == txtPriceMin && String.IsNullOrWhiteSpace(txtPriceMin.Text))
            {
                return;
            }
            if (Double.Parse(txtPriceMin.Text) > Double.Parse(txtPriceMax.Text))
            {
                txtPriceMin.ForeColor = Color.Red;
                txtPriceMax.ForeColor = Color.Red;
            }
            else
            {
                txtPriceMin.ForeColor = Color.Black;
                txtPriceMax.ForeColor = Color.Black;
            }
        }

        private void onUnitTextChanged(object sender, EventArgs e)
        {
            if (sender == txtUnitMin && String.IsNullOrWhiteSpace(txtUnitMin.Text))
            {
                return;
            }
            if (sender == txtUnitMax && String.IsNullOrWhiteSpace(txtUnitMax.Text))
            {
                return;
            }
            if (Double.Parse(txtUnitMin.Text) > Double.Parse(txtUnitMax.Text))
            {
                txtUnitMax.ForeColor = Color.Red;
                txtUnitMin.ForeColor = Color.Red;
            }
            else
            {
                txtUnitMin.ForeColor = Color.Black;
                txtUnitMax.ForeColor = Color.Black;
            }
        }
    }
}
