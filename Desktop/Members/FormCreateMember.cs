using BusinessObject;
using Desktop.common;
using Desktop.common.Roles;
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
using DataAccess.repositories.Members;

namespace Desktop.Members
{
    public partial class FormCreateMember : Form
    {
        private IMemberRepository MemberRepository;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        public FormCreateMember(IServiceProvider serviceProvider, AppSetting appSetting, AppRoles appRole, IMemberRepository memberRepository)
        {
            _serviceProvider = serviceProvider;
            MemberRepository = memberRepository;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var memberInfo = ucMemberInfo.GetUserInput();

            if (memberInfo != null)
            {
                var value = memberInfo.Value;

                    if (MemberRepository.GetByEmail(value.email) != null)
                    {
                        this.ShowOkErrorMessageBox("Email: " + value.email + " already exist!");
                        return; 
                    }
                    MemberRepository.Add(value.country, value.city, value.password, value.email, value.name, value.companyName);

                MessageBox.Show("Add member successfully !!", "Create member", MessageBoxButtons.OK);

                ucMemberInfo.ClearInput();
            }

        }
    }
}
