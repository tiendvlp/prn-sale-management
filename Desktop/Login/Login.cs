using BusinessObject;
using DataAccess.repositories.Members;
using Desktop.common;
using Desktop.common.Roles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Desktop.Login
{
    public partial class Login : Form
    {

        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        private IMemberRepository MemberRepository;
        public Login(IServiceProvider serviceProvider, AppSetting appSetting, AppRoles appRole, IMemberRepository memberRepository)
        {
            _serviceProvider = serviceProvider;
            _appSetting = appSetting;
            MemberRepository = memberRepository;
            _appRole = appRole;
            InitializeComponent();
            LoadLoginLayout();
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void LoadLoginLayout ()
        {
            txtUserName.AutoSize = false;
        }

        private void OnBtnLoginClicked(object sender, EventArgs e)
        {
            {
                Console.WriteLine("User login");
                String email = txtUserName.Text;
                String password = txtPassword.Text;

                if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Your email or password can not be empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // check admins
                bool isAdmin = false;
                _appSetting.Admins.ToList().ForEach(admin =>
                {
                    if (admin.Email.Equals(email) && admin.Password.Equals(password))
                    {
                        isAdmin = true;
                    }
                });

                if (isAdmin)
                {
                    this.Hide();
                    _appRole.CurrentRole = new UserRole.Admin();
                    MainForm.MainForm mainForm = _serviceProvider.GetRequiredService<MainForm.MainForm>();
                    mainForm.Closed += (s, args) => this.Close();
                    mainForm.Show();
                    return;
                }

                Member member = MemberRepository.GetByEmail(email);
                if (member == null)
                {
                    MessageBox.Show("Your email or password is incorrect", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (member.Password.Equals(password))
                {
                    _appRole.CurrentRole = new UserRole.Member(member);
                    MainForm.MainForm mainForm = _serviceProvider.GetRequiredService<MainForm.MainForm>();
                    mainForm.Show();
                    this.Hide();
                }
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
