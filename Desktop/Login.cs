using BusinessObject;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Login()
        {
            _unitOfWorkFactory = (UnitOfWorkFactory)Program.ServiceProvider.GetService(typeof(UnitOfWorkFactory));
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
