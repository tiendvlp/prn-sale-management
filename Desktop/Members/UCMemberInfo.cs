using BusinessObject;
using System;
using System.Windows.Forms;

namespace Desktop.Members
{
    public partial class UCMemberInfo : UserControl
    {
        public UCMemberInfo()
        {
            InitializeComponent();
        }


        public (string name, string email, string password, string city, string country, string companyName)? GetUserInput()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("User name can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("User email can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("User password can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("User city can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtCountry.Text))
            {
                MessageBox.Show("User country can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("User company name can not be empty", "Missing info", MessageBoxButtons.OK);
                return null;
            }

            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string city = txtCity.Text;
            string country = txtCountry.Text;
            string companyName = txtCompanyName.Text;

            return (
                    name: name, email: email, password: password, city:city, country: country
                    , companyName:companyName
                );
        }

        internal void ClearInput()
        {
           txtName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            txtCompanyName.Clear();
        }


        internal void SetContent(Member member)
        {
            txtName.Text = member.Name;
            txtEmail.Text = member.Email;
            txtPassword.Text = member.Password;
            txtCity.Text = member.City;
            txtCountry.Text = member.Country;
            txtCompanyName.Text = member.CompanyName;
        }
    }
}
