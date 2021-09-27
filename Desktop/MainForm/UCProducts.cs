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

namespace Desktop.MainForm
{
    public partial class UCProducts : UserControl
    {
        public static int ADMIN_MODE = 1;
        public static int MEMBER_MODE = 2;

        private int _mode;
        
        private ColumnHeader ProductNameColumn = new ColumnHeader("Name");
        private ColumnHeader ProductPriceColumn = new ColumnHeader("Price");
        private ColumnHeader ProductCategoryColumn = new ColumnHeader("Category");
        private ColumnHeader ProducWeightColumn = new ColumnHeader("Weight");
        private ColumnHeader ProductQuantityColumn = new ColumnHeader("Quantity");

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

        public void AddProduct (List<Product> product)
        {
            product.ForEach(product => AddProduct(product));
        }

        public void AddProduct (Product product)
        {
            var newItem = new ListViewItem();
            newItem.Tag = product;
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = product.Name
            });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem()
            {
                Text = product.Price + ""
            });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem() {
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
                    } else
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
            }
        }

        private void OnAdminMenu_click(object sender, EventArgs e)
        {
            var focusedItem = lvProduct.FocusedItem;
            if (focusedItem != null)
            {
                Product focusedProduct = (Product)focusedItem.Tag;
                new FormCreateProduct().ShowDialog();
            }
        }
    }
}
