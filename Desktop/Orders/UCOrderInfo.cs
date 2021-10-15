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

namespace Desktop.Orders
{
    public partial class UCOrderInfo : UserControl
    {
        private List<Product> _boughtProduct;
        public class DataBinding
        {
           public List<Product> Products { get; internal set; }
           public String memberEmail { get; internal set; }
           public DateTime RequiredDate { get; internal set; }
           public DateTime ShippedDate { get; internal set; }
           public Dictionary<String, int> Quantity { get; internal set; }
            public double freight;

            public DataBinding(List<Product> Products, Dictionary<String, int> Quantity, double freight, String email, DateTime shippedDate, DateTime requiredDate)
            {
                this.memberEmail = email;
                this.freight = freight;
                this.Products = Products;
                this.Quantity = Quantity;
                ShippedDate = shippedDate;
                RequiredDate = requiredDate;
            }
        }
        double totalPrice = 0;
        public UCOrderInfo()
        {
            InitializeComponent();
        }

        public enum EVENT_TYPE
        {
            CANCEL
        }
        private Dictionary<String, int> Quantity = new Dictionary<string, int>();
        private double _freight = 0;
        public delegate void OnEvent (EVENT_TYPE type, Object data);

        public OnEvent CallBack { get; set; }
     
        internal void SetProducts(List<Product> boughtProducts)
        {
            lvProduct.Controls.Clear();
            _boughtProduct = boughtProducts;

            lvProduct.AutoScroll = true;
            lvProduct.FlowDirection = FlowDirection.TopDown;
            lvProduct.WrapContents = false; // Vertical rather than horizontal scrolling

            _boughtProduct.ForEach(product => AddProduct(product));

            _calculateFreightAndPrice();
        }

        private void _reload ()
        {
            SetProducts(_boughtProduct);
        }

        public DataBinding getData ()
        {
            foreach (var c in lvProduct.Controls)
            {
                UCItemProducts uc = c as UCItemProducts;
                if (!Quantity.ContainsKey(uc.Data.Data.Id))
                {
                    Quantity.Add(uc.Data.Data.Id, uc.Data.Quantity);
                } else
                {
                    Quantity[uc.Data.Data.Id] = uc.Data.Quantity;
                }
            }

            var result = new DataBinding(_boughtProduct, Quantity, _freight, txtEmail.Text, dateTimeShippedDatePicker.Value, datePickerRequiredDate.Value);
            return result;
        }

        public void SetMemberInfo (String memberEmail)
        {
            txtEmail.Text = memberEmail;
        }
        public void AddProduct(Product product)
        {       
                UCItemProducts newItem = new UCItemProducts();
                newItem.Bind(product);
                newItem.Callback = OnItemEvent;
                lvProduct.Controls.Add(newItem);
        }

        private void OnItemEvent(UCItemProducts.EVENT_TYPE type, UCItemProducts.DataBinding data)
        {
            if (type == UCItemProducts.EVENT_TYPE.DELETE)
            {
                _boughtProduct.RemoveAll(p => p.Id.Equals(data.Data.Id));
                _reload();
            }

            if (type == UCItemProducts.EVENT_TYPE.UPDATE_QUANTITY)
            {
                _calculateFreightAndPrice();
            }

            if (_boughtProduct.Count == 0)
            {
                CallBack(EVENT_TYPE.CANCEL, null);
            }
        }

        private void _calculateFreightAndPrice(double overrideFreight = -1)
        {
            // call getData to refresh the Quantity dictionary
            getData();
            totalPrice = 0;
            _freight = 0;
            _boughtProduct.ForEach(p =>
           {
               if (Quantity.ContainsKey(p.Id))
               {
                   totalPrice += p.Price * Quantity[p.Id];
                   _freight += p.Weight * 0.1 * Quantity[p.Id];
               } else
               {
                   totalPrice += p.Price;
                   _freight += p.Weight * 0.1;
               }
              
           });
            if (overrideFreight != -1)
            {
                _freight = overrideFreight;
            }
            totalPrice += _freight;
            _freight = Math.Round(_freight, 2);
            totalPrice = Math.Round(totalPrice, 2);
            lblPrice.Text = totalPrice + "$";
            txtFrieght.Text = _freight + "$";
        }


        internal void SetOrderInfo (DateTime orderDate, DateTime shippedDate, DateTime? requiredDate = null, double freight = -1 )
        {
            lblOrderDate.Text = orderDate.ToString("yyyy-dd-MM");
            dateTimeShippedDatePicker.Value = shippedDate;
            if (requiredDate == null)
            {
                // by default the required date is equals to shipped date
                datePickerRequiredDate.Value = shippedDate;
            } else
            {
                datePickerRequiredDate.Value = requiredDate.Value;
            }
            if (freight != -1)
            {
                txtFrieght.Text = freight + "$";
            }
        }

        internal DateTime getRequiredDate ()
        {
            return datePickerRequiredDate.Value;
        }

        private void datePickerRequiredDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFreight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFrieght_TextChanged(object sender, EventArgs e)
        {
            double f = 0;
            bool result = double.TryParse(txtFrieght.Text.Replace("$",""), out f);
            if (result)
            {
                _calculateFreightAndPrice(f);
            }
        }

        private void dateTimeShippedDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
