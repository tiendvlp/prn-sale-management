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
using Desktop.common.Roles;

namespace Desktop.MainForm
{
    public partial class MainForm : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private IServiceProvider serviceProvider;
        private Form _activeForm;
        private AppRoles appRoles;
        public MainForm(UnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, AppRoles appRoles)
        {
            this.appRoles = appRoles;
            _unitOfWorkFactory = unitOfWorkFactory;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
            _setupRole();
            _setDefaultTab();
        }

        private void _setDefaultTab()
        {
            if (appRoles.IsAdmin)
            {
                _openChildForm(serviceProvider.GetRequiredService<FormMembers>());
            } else
            {
                _openChildForm(serviceProvider.GetRequiredService<FormProducts>());
            }
        }

        private void _setupRole ()
        {
            if (appRoles.IsAdmin)
            {
                btnMembers.Enabled = true;
                btnMembers.Visible = true;
                btnUserInfo.Enabled = false;
                btnUserInfo.Visible = false;
                lblUserName.Text = "Welcome admin";
            }
            else
            {
                btnMembers.Enabled = false;
                btnMembers.Visible = false;

                btnUserInfo.Enabled = true;
                btnUserInfo.Visible = true;
            }
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                FormUpdateMember updateMembers = ActivatorUtilities.CreateInstance<FormUpdateMember>(serviceProvider, (appRoles.CurrentRole as UserRole.Member).Info);
                updateMembers.ShowDialog();
            }
            using (var work = _unitOfWorkFactory.UnitOfWork)
            {
                Member m = work.MemberRepository.GetById((appRoles.CurrentRole as UserRole.Member).Info.Id);
                appRoles.CurrentRole = new UserRole.Member(m);
                lblUserName.Text = m.Name;
            }
            
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            // clear app roles
            appRoles.CurrentRole = null;
            // go back to login screen
            this.Hide();
            appRoles.CurrentRole = null;
            Login loginForm = serviceProvider.GetRequiredService<Login>();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
            return;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {

            if (_activeForm is FormProducts)
            {
                return;
            }
            _openChildForm(serviceProvider.GetRequiredService<FormProducts>());
        }
      

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (_activeForm is FormMembers)
            {
                return;
            }
            _openChildForm(serviceProvider.GetRequiredService<FormMembers>());
        }

        private void _openChildForm(Form childForm )
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
