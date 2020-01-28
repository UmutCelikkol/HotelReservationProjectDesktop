using Project.MODEL.Entities;
using Project.WinUI.AdminForms.AttributeForms;
using Project.WinUI.AdminForms.CustomerForms;
using Project.WinUI.AdminForms.ProductForms;
using Project.WinUI.AdminForms.RoomForms;
using Project.WinUI.AdminForms.TypeForms;
using Project.WinUI.AdminForms.UserForms;
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
    public partial class AdminForm : Form
    {
        public AdminForm(AppUser user)
        {
            InitializeComponent();
            currentUser = user;
        }
        public AdminForm()
        {
            InitializeComponent();
          
        }
        AppUser currentUser;

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (currentUser is null)
            {
                this.Text = $"Welcome again!";
            }
            else
            {
                this.Text = $"Welcome {currentUser.UserName}!";
            }
      
        }

        private void BtnAddRoom_Click(object sender, EventArgs e)
        {
            AddRoom addRoom = new AddRoom();
            this.Hide();
            addRoom.Show();
        }

        private void BtnUpdateRoom_Click(object sender, EventArgs e)
        {
            UpdateRoom updateRoom = new UpdateRoom();
            this.Hide();
            updateRoom.Show();
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            this.Hide();
            addUser.Show();
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            this.Hide();
            updateUser.Show();
        }


        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            this.Hide();
            addProduct.Show();
        }

        private void BtnUpdateProduct_Click(object sender, EventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            this.Hide();
            updateProduct.Show();
        }

        private void BtnAddAttribute_Click(object sender, EventArgs e)
        {
            AddAttribute addAttribute = new AddAttribute();
            this.Hide();
            addAttribute.Show();
        }

        private void BtnUpdateAttribute_Click(object sender, EventArgs e)
        {
            UpdateAttribute updateAttribute = new UpdateAttribute();
            this.Hide();
            updateAttribute.Show();
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            this.Hide();
            addCustomer.Show();
        }

        private void BtnUpdateCustomer_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            this.Hide();
            updateCustomer.Show();
        }

        private void BtnAddType_Click(object sender, EventArgs e)
        {
            AddType addType = new AddType();
            this.Hide();
            addType.Show();
        }

        private void BtnUpdateType_Click(object sender, EventArgs e)
        {
            UpdateType updateType = new UpdateType();
            this.Hide();
            updateType.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            this.Hide();
            lgn.Show();

        }
    }
}
