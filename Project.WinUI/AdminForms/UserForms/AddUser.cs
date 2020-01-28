using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using Project.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI.AdminForms.UserForms
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            appUserRepository = new AppUserRepository();
            profileRepository = new ProfileRepository();
        }
        AppUserRepository appUserRepository;
        ProfileRepository profileRepository;

        private void AddUser_Load(object sender, EventArgs e)
        {
            cbRoles.DataSource = Enum.GetValues(typeof(UserRole));
            cbRoles.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AppUser appUser = new AppUser();
            appUser.UserName = txtUserName.Text;
            appUser.Password = txtPassword.Text;
            appUser.Role = (UserRole)cbRoles.SelectedItem;
            appUserRepository.Add(appUser);

            Profile profile = new Profile();
            profile.FirstName = txtFirstName.Text;
            profile.LastName = txtLastName.Text;
            profile.AppUser = appUser;
            profileRepository.Add(profile);

            ClearTextBoxes();
        }

        void ClearTextBoxes()
        {
            foreach (Control t in this.Controls)
            {
                if (t is TextBox)
                {
                    ((TextBox)t).Text = String.Empty;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm adm = new AdminForm();
            this.Hide();
            adm.Show();
        }
    }
}
