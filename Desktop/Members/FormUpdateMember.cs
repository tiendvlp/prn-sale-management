using BusinessObject;
using DataAccess.repositories.Members;
using Desktop.common;
using Desktop.common.Roles;
using System;
using System.Windows.Forms;

namespace Desktop.Members
{
    public partial class FormUpdateMember : Form
    {
        private IMemberRepository MemberRepository;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        private Member _member;
        public FormUpdateMember(IServiceProvider serviceProvider, AppSetting appSetting, AppRoles appRole, Member member, IMemberRepository memberRepository)
        {
            _member = member;
            _serviceProvider = serviceProvider;
            MemberRepository = memberRepository;
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
                    _member.Name = value.name;
                    _member.Password = value.password;
                    _member.Email = value.email;
                    _member.Country = value.country;
                    _member.City = value.city;
                    _member.CompanyName = value.companyName;

                    MemberRepository.Update(_member);
                    _member = MemberRepository.GetById(_member.Id);
                    _setUpdateMember();

                MessageBox.Show("Update member successfully !!", "Update member", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Update member failed !!", "Update member", MessageBoxButtons.OK);
            }
        }
    }
}
