using DataAccess.UnitOfWork;
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
    public partial class MainForm : Form
    {
        UnitOfWorkFactory _unitOfWorkFactory;

        public MainForm(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            InitializeComponent();
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {

        }

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (!tbnContainer.Controls.ContainsKey(nameof(UCProducts)))
            {
                var uc = new UCProducts(UCProducts.ADMIN_MODE);
                uc.Dock = DockStyle.Fill;
                tbnContainer.Controls.Add(uc);
                // shows products
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    uc.AddProduct(work.ProductRepository.GetAll().ToList());
                }
            }

            tbnContainer.Controls[nameof(UCProducts)].BringToFront();


        }

        private void btnMembers_Click(object sender, EventArgs e)
        {

        }
    }
}
