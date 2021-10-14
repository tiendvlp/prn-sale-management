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

        double totalPrice = 0;
        public UCOrderInfo()
        {
            InitializeComponent();
            _initListView();
        }

        private void _initListView()
        {
        }

     
        internal void SetProducts(List<Product> boughtProducts)
        {
            _boughtProduct = boughtProducts;
            _boughtProduct.ForEach(product => {
                AddProduct(product);
                totalPrice += product.Price;
            });

            lvProduct.AutoScroll = true;
            lvProduct.FlowDirection = FlowDirection.TopDown;
            lvProduct.WrapContents = false; // Vertical rather than horizontal scrolling

            _boughtProduct.ForEach(product => AddProduct(product));
        }

        public void AddProduct(Product product)
        {
                UCItemProducts newItem = new UCItemProducts();
                newItem.Bind(product);
                lvProduct.Controls.Add(newItem);
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
