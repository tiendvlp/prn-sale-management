using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.Products;
using Microsoft.Extensions.DependencyInjection;
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
using Desktop.Members;

namespace Desktop.MainForm
{
    public partial class MainForm : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;
        private Form _activeForm;
        public MainForm(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
        }


        private void btnUserInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {

            if (_activeForm is FormProducts)
            {
                return;
            }
            _openChildForm(serviceProvider.GetRequiredService<FormProducts>(), e);
        }


      

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (_activeForm is FormMembers)
            {
                return;
            }
            _openChildForm(serviceProvider.GetRequiredService<FormMembers>(), e);
        }

        private void _openChildForm(Form childForm, object btnSender)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            tbnContainer.Controls.Add(childForm);
            tbnContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
