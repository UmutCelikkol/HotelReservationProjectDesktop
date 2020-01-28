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
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
            appUserRepository = new AppUserRepository();
            profileRepository = new ProfileRepository();
        }
        AppUser appUser;
        Profile profile;
        AppUserRepository appUserRepository;
        ProfileRepository profileRepository;

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            LoadListBox();
            cbRoles.DataSource = Enum.GetValues(typeof(UserRole));
            cbRoles.SelectedIndex = 0;
        }

        void LoadListBox()
        {
            lstAppUsers.DataSource = appUserRepository.GetActives();
            lstAppUsers.SelectedIndex = -1;
        }

        private void LstAppUsers_Click(object sender, EventArgs e)
        {
            if (lstAppUsers.SelectedIndex > -1)
            {
                appUser = lstAppUsers.SelectedItem as AppUser;
                profile = appUser.Profile;
                txtUserName.Text = appUser.UserName;
                txtPassword.Text = appUser.Password;
                cbRoles.SelectedItem = (UserRole)appUser.Role;
                txtFirstName.Text = profile.FirstName;
                txtLastName.Text = profile.LastName;
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstAppUsers.SelectedIndex > -1)
            {
                AppUser appUser = lstAppUsers.SelectedItem as AppUser;
                appUser.UserName = txtUserName.Text;
                appUser.Password = txtPassword.Text;
                appUser.Role = (UserRole)cbRoles.SelectedItem;
                Profile profile = appUser.Profile;
                profile.FirstName = txtFirstName.Text;
                profile.LastName = txtLastName.Text;
                appUserRepository.Update(appUser);
                profileRepository.Update(profile);
                LoadListBox();
                ClearTextBoxes();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstAppUsers.SelectedIndex > -1)
            {
                profileRepository.Delete(profile);
                appUserRepository.Delete(appUser);
                LoadListBox();
                ClearTextBoxes();
            }
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

        private void btnreturn_Click(object sender, EventArgs e)
        {
            AdminForm adm = new AdminForm();
            this.Hide();
            adm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser atm = new AddUser();
            atm.Show();
            this.Hide();
        }
    }
}
