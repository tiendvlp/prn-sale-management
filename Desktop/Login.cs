using BusinessObject;
using DataAccess.UnitOfWork;
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
namespace Desktop
{
    public partial class Login : Form
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private AppSetting _appSetting;
        private AppRoles _appRole;
        private IServiceProvider _serviceProvider;
        public Login(IServiceProvider serviceProvider, UnitOfWorkFactory unitOfWorkFactory, AppSetting appSetting, AppRoles appRole)
        {
            _serviceProvider = serviceProvider;
            _unitOfWorkFactory = unitOfWorkFactory;
            _appSetting = appSetting;
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
            using(UnitOfWork work = _unitOfWorkFactory.UnitOfWork)
            {
                Console.WriteLine("User login");
                String email = txtUserName.Text;
                String password = txtPassword.Text;

                if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show( "Your email or password can not be empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // check admins
                bool isAdmin = false;
                _appSetting.Admins.ToList().ForEach(admin => { 
                    if (admin.Email.Equals(email) && admin.Password.Equals(password))
                    {
                        isAdmin = true;
                    }
                });

                if (isAdmin)
                {
                    _appRole.CurrentRole = new UserRole.Admin();
                    MessageBox.Show("Welcome host", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MainForm.MainForm mainForm = _serviceProvider.GetRequiredService<MainForm.MainForm>();
                    mainForm.Show();
                    this.Hide();
                    return;
                }

                Member member = work.MemberRepository.GetByEmail(email);
                if (member == null)
                {
                    MessageBox.Show("Your email or password is incorrect", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (member.Password.Equals(password))
                {
                    Console.WriteLine("Login success");
                }
            }
        }
    }
}
