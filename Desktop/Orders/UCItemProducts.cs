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
using Desktop.common.MessageBoxHelper;
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
        public enum EVENT_TYPE
        {
            DELETE, UPDATE_QUANTITY
        }

        public delegate void OnEvent(EVENT_TYPE type, DataBinding Data);

        public OnEvent Callback { get; set; }

        public UCItemProducts()
        {
            InitializeComponent();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Callback != null)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete " + Data.Data.Name + " !", "Confirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Callback(EVENT_TYPE.DELETE, Data);
                }
            }
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
        }

        private void txtQuantity_TextChanged_1(object sender, EventArgs e)
        {
            if (Data == null) { return; }
            int previousQuantity = Data.Quantity;
            int quantity = 0;
            bool parseResult = int.TryParse(txtQuantity.Text, out quantity );

            if (parseResult)
            {
                Data.Quantity = quantity;
            } else
            {
                return;
            }

            if (Data.Quantity == 0)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete " + Data.Data.Name + " !", "Confirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (Callback != null)
                    {
                        Callback(EVENT_TYPE.DELETE, Data);
                    }
                } else
                {
                    Data.Quantity = 1;
                    txtQuantity.Text = Data.Quantity + "";
                }

                return;
            }
            Callback(EVENT_TYPE.UPDATE_QUANTITY, Data);
        }
    }
}
