using BusinessObject;
using DataAccess.UnitOfWork;
using Desktop.common;
using Desktop.common.Roles;
using System;
using System.Windows.Forms;

namespace Desktop.Members
{
    public partial class FormUpdateMember : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        private Member _member;
        public FormUpdateMember(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole, Member member)
        {
            _member = member;
            _serviceProvider = serviceProvider;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
            _appRole = appRole;
            InitializeComponent();
            _setUpdateMember();
        }

        private void _setUpdateMember()
        {
            ucMemberInfo.SetContent(_member);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var productInfo = ucMemberInfo.GetUserInput();


            if (productInfo != null)
            {
                var value = productInfo.Value;
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    _member.Name = value.name;
                    _member.Password = value.password;
                    _member.Email = value.email;
                    _member.Country = value.country;
                    _member.City = value.city;
                    _member.CompanyName = value.companyName;

                    work.MemberRepository.Update(_member);
                    work.Save();
                }
                using (var work = _unitOfWorkFactory.UnitOfWork)
                {
                    _member = work.MemberRepository.GetById(_member.Id);
                    _setUpdateMember();
                }

                MessageBox.Show("Update member successfully !!", "Update member", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Update member failed !!", "Update member", MessageBoxButtons.OK);
            }
        }
    }
}
