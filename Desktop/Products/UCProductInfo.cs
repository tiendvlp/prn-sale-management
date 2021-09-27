﻿using System;
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
    public partial class UCProductInfo : UserControl
    {
        public UCProductInfo()
        {
            InitializeComponent();
        }

        private void OnTxtProductName_KeyDown(object sender, KeyPressEventArgs e)
        {

        }

        public (string name, string category, float price, float weight, string unit, int quantity)? GetProductInput ()
        {
            if (String.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Your product name can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtProductQuantity.Text))
            {
                MessageBox.Show("Your product quantity can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtProductWeight.Text))
            {
                MessageBox.Show("Your product weight can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                MessageBox.Show("Your product price can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            string name = txtProductName.Text;
            int quantity = int.Parse(txtProductQuantity.Text);
            string unit = cbxWeightUnits.Text;
            float weight = float.Parse(txtProductWeight.Text);
            float price = float.Parse(txtProductPrice.Text);
            string category = cbxCategories.Text;

            return (name, category,price, weight, unit, quantity);
        }

        private void OnTxtProductWeight_KeyDown(object sender, KeyPressEventArgs e)
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

        private void OnTxtProductQuantity_KeyDown(object sender, KeyPressEventArgs e)
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

        private void OnTxtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
