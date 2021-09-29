using BusinessObject;
using DataAccess.UnitOfWork;
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

namespace Desktop.Members
{
    public partial class FormCreateMember : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        public FormCreateMember(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole)
        {
            _serviceProvider = serviceProvider;
            _unitOfWorkFactory = unitOfWorkFactory;
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

                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    work.MemberRepository.Add(value.country, value.city, value.password, value.email, value.name, value.companyName);
                    work.Save();
                }

                MessageBox.Show("Add member successfully !!", "Create member", MessageBoxButtons.OK);

                ucMemberInfo.ClearInput();
            }

        }
    }
}
