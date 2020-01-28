using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.WinUI.CustomerForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            appUserRepository = new AppUserRepository();
        }

        AppUserRepository appUserRepository;

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (appUserRepository.Any(x => x.UserName == txtUserName.Text
                                        && x.Password == txtPassword.Text
                                        && x.Role == MODEL.Enums.UserRole.Admin))
            {
                AdminForm adminForm = new AdminForm(appUserRepository.FirstOrDefault(x => x.UserName == txtUserName.Text
                                        && x.Password == txtPassword.Text
                                        && x.Role == MODEL.Enums.UserRole.Admin));
                this.Hide();
                adminForm.Show();
            }
            else if (appUserRepository.Any(x => x.UserName == txtUserName.Text
                                        && x.Password == txtPassword.Text
                                        && x.Role == MODEL.Enums.UserRole.Employee))
            {
                EmployeeForm employeeForm = new EmployeeForm(appUserRepository.FirstOrDefault(x => x.UserName == txtUserName.Text
                                        && x.Password == txtPassword.Text
                                        && x.Role == MODEL.Enums.UserRole.Employee));
                this.Hide();
                employeeForm.Show();
            }
            else
            {
                MessageBox.Show("Unidentified User!");
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
