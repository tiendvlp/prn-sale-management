using BusinessObject;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Desktop.common.MessageBoxHelper;
using Desktop.Members;
using Desktop.common.Roles;
using DataAccess.repositories.Members;
using Desktop.Login;

namespace Desktop.MainForm
{
    public partial class MainForm : Form
    {
        private IServiceProvider serviceProvider;
        private Form _activeForm;
        private AppRoles appRoles;

        private IMemberRepository MemberRepository;
        public MainForm(IServiceProvider serviceProvider, AppRoles appRoles, IMemberRepository memberRepository)
        {
            this.appRoles = appRoles;
            this.serviceProvider = serviceProvider;
            MemberRepository = memberRepository;
            InitializeComponent();
            _setupRole();
            _showDefaultForm();
        }

        private void _showDefaultForm ()
        {
            if (appRoles.IsAdmin)
            {
                _openChildForm(serviceProvider.GetRequiredService<FormMembers>());
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
                lblUserName.Text = (appRoles.CurrentRole as UserRole.Member).Info.Name;
                btnUserInfo.Enabled = true;
                btnUserInfo.Visible = true;
            }
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
                FormUpdateMember updateMembers = ActivatorUtilities.CreateInstance<FormUpdateMember>(serviceProvider, (appRoles.CurrentRole as UserRole.Member).Info);
                updateMembers.ShowDialog();
                Member m = MemberRepository.GetById((appRoles.CurrentRole as UserRole.Member).Info.Id);
                appRoles.CurrentRole = new UserRole.Member(m);
                lblUserName.Text = m.Name;
            
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            // clear app roles
            appRoles.CurrentRole = null;
            // go back to login screen
            this.Hide();
            appRoles.CurrentRole = null;
            Login.Login loginForm = serviceProvider.GetRequiredService<Login.Login>();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
            return;
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (_activeForm is FormMembers)
            {
                return;
            }
            _openChildForm(serviceProvider.GetRequiredService<FormMembers>());
        }

        private void _openChildForm(Form childForm)
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
