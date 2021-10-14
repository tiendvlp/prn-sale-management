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
           public DateTime RequiredDate { get; internal set; }
           public Dictionary<String, int> Quantity { get; internal set; }

            public DataBinding(List<Product> Products, Dictionary<String, int> Quantity)
            {
                this.Products = Products;
                this.Quantity = Quantity;
            }
        }
        double totalPrice = 0;
        public UCOrderInfo()
        {
            InitializeComponent();
            _initListView();
        }

        public enum EVENT_TYPE
        {
            CANCEL
        }
        private Dictionary<String, int> Quantity = new Dictionary<string, int>();
        public delegate void OnEvent (EVENT_TYPE type, Object data);

        public OnEvent CallBack { get; set; }

        private void _initListView()
        {
        }
     
        internal void SetProducts(List<Product> boughtProducts)
        {
            lvProduct.Controls.Clear();
            _boughtProduct = boughtProducts;

            lvProduct.AutoScroll = true;
            lvProduct.FlowDirection = FlowDirection.TopDown;
            lvProduct.WrapContents = false; // Vertical rather than horizontal scrolling

            _boughtProduct.ForEach(product => AddProduct(product));

            lblPrice.Text = totalPrice + "";

        }

        public DataBinding getData ()
        {

            foreach (var c in lvProduct.Controls)
            {
                UCItemProducts uc = c as UCItemProducts;
                Quantity.Add(uc.Data.Data.Id, uc.Data.Quantity);
            }

            var result = new DataBinding(_boughtProduct, Quantity);
            result.RequiredDate = datePickerRequiredDate.Value;
            return result;
        }

        public void AddProduct(Product product)
        {
                totalPrice += product.Price;
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
                SetProducts(_boughtProduct);
            }

            if (_boughtProduct.Count == 0)
            {
                CallBack(EVENT_TYPE.CANCEL, null);
            }
        }

        internal void SetUserInfo(String city, String company, String country, String email)
        {
            lblCity.Text = city;
            lblCompany.Text = company;
            lblCountry.Text = country;
            lblEmail.Text = email;
        }

        internal void SetOrderInfo (DateTime orderDate, DateTime shippedDate )
        {
            lblOrderDate.Text = orderDate.ToString("yyyy-dd-MM");
            lblShippedDate.Text = shippedDate.ToString("yyyy-dd-MM");
            datePickerRequiredDate.Value = shippedDate;
        }

        internal DateTime getRequiredDate ()
        {
            return datePickerRequiredDate.Value;
        }

        private void datePickerRequiredDate_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
