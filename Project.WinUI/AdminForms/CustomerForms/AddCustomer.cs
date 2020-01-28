using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI.AdminForms.CustomerForms
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
        }
        CustomerRepository customerRepository;
        AppUser user;
        private void AddCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "Add Customer Menu";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.FirstName = txtName.Text;
            customer.LastName = txtLastName.Text;
            customer.TCNo = txtTCNo.Text;
            customerRepository.Add(customer);
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm adm = new AdminForm(user);
            this.Hide();
            adm.Show();
        }
    }
}
