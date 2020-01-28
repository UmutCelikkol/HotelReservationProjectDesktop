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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
        }
        Customer customer;
        CustomerRepository customerRepository;

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "Update Customer Menu";
            LoadListBox();
        }

        void LoadListBox()
        {
            lstCustomers.DataSource = customerRepository.GetActives();
            lstCustomers.SelectedIndex = -1;
        }

        private void LstCustomers_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex > -1)
            {
                customer = lstCustomers.SelectedItem as Customer;
                txtName.Text = customer.FirstName;
                txtLastName.Text = customer.LastName;
                txtTCNo.Text = customer.TCNo;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex > -1)
            {
                customer.FirstName = txtName.Text;
                customer.LastName = txtLastName.Text;
                customer.TCNo = txtTCNo.Text;
                customerRepository.Update(customer);
                LoadListBox();
                ClearTextBoxes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex > -1)
            {
                customerRepository.Delete(customer);
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
            AddCustomer att = new AddCustomer();
            this.Hide();
            att.Show();
        }
    }
}
