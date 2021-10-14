using BusinessObject;
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
    public partial class UCItemProducts : UserControl
    {
        public class DataBinding {
            public Product Data { get; internal set; }
            public int Quantity { get; internal set; }

            public DataBinding(Product data, int quantity)
            {
                this.Data = data;
                this.Quantity = quantity;
            }
        }
        public DataBinding Data { get; private set; }
        public UCItemProducts()
        {
            InitializeComponent();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        public void Bind (Product product)
        {
            lblPrice.Text = product.Price + "$";
            lblTitle.Text = product.Name;
            txtQuantity.Text = 1 + "";
            Data = new DataBinding(product, 1);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

            Data.Quantity = int.Parse(txtQuantity.Text);
        }
    }
}
