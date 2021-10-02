using BusinessObject;
using Desktop.Products;
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
    public partial class UCProducts : UserControl
    {
        public enum EVENT
        {
            DELETE, UPDATE, BUY
        }

        public enum TASK_BAR_EVENT
        {
            CREATE, DELETE
        }

        public delegate void OnActionOccurs(EVENT e, Product product);
        public delegate void OnTaskBarActionOccurs(TASK_BAR_EVENT e, List<Product> product);

        public OnActionOccurs CallBack = null;
        public OnTaskBarActionOccurs TaskBarActionCallBack = null;

        public static int ADMIN_MODE = 1;
        public static int MEMBER_MODE = 2;
        private int _mode;
        private ColumnHeader ProductNameColumn = new ColumnHeader("Name") { Text = "Name" };
        private ColumnHeader ProductPriceColumn = new ColumnHeader("Price") { Text = "Price" };
        private ColumnHeader ProductCategoryColumn = new ColumnHeader("Category") { Text = "Category" };
        private ColumnHeader ProducWeightColumn = new ColumnHeader("Weight") { Text = "Weight" };
        private ColumnHeader ProductQuantityColumn = new ColumnHeader("Quantity") { Text = "Quantity" };

        public UCProducts(int mode)
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
            if (CallBack == null)
            {
                return;
            }
            var focusedItem = lvProduct.FocusedItem;
            if (focusedItem != null)
            {
                Product focusedProduct = (Product)focusedItem.Tag;
                string eventName = (sender as ToolStripItem).Text;
                if (eventName == "Buy")
                {
                    CallBack(EVENT.BUY, focusedProduct);
                    return;
                }
            }
        }

        private void OnAdminMenu_click(object sender, EventArgs e)
        {
            if (CallBack == null)
            {
                return;
            }
            var focusedItem = lvProduct.FocusedItem;
            if (focusedItem != null)
            {
                Product focusedProduct = (Product)focusedItem.Tag;

                string eventName = (sender as ToolStripItem).Text;
                if (eventName == "Delete")
                {
                    CallBack(EVENT.DELETE, focusedProduct);
                    return;
                }
                if (eventName == "Update")
                {
                    CallBack(EVENT.UPDATE, focusedProduct);
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TaskBarActionCallBack == null) { return; }
            List<Product> selectedProduct = new List<Product>();

            for (int i = 0; i < lvProduct.CheckedItems.Count; i++)
            {
                Console.WriteLine("hihi selected");
                var item = lvProduct.CheckedItems[i];
                selectedProduct.Add((Product)item.Tag);
            }

            TaskBarActionCallBack(TASK_BAR_EVENT.DELETE, selectedProduct);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (TaskBarActionCallBack == null) { return; }
            List<Product> selectedProduct = new List<Product>();
            for (int i = 0; i < lvProduct.SelectedItems.Count; i++)
            {
                var item = lvProduct.SelectedItems[i];
                selectedProduct.Add((Product)item.Tag);
            }

            TaskBarActionCallBack(TASK_BAR_EVENT.CREATE, selectedProduct);
        }
    }
}
