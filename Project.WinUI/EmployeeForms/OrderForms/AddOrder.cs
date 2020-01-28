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

namespace Project.WinUI.CustomerForms.OrderForms
{
    public partial class AddOrder : Form
    {
        public AddOrder(AppUser user, Customer customer)
        {
            InitializeComponent();
            currentUser = user;
            currentCustomer = customer;
            productRepository = new ProductRepository();
            orderRepository = new OrderRepository();
        }
        AppUser currentUser;
        Customer currentCustomer;
        ProductRepository productRepository;
        OrderRepository orderRepository;

        private void AddOrder_Load(object sender, EventArgs e)
        {
            this.Text = currentUser.UserName;
            foreach (Product p in productRepository.GetActives())
            {
                CheckBox c = new CheckBox();
                c.Text = p.ToString();
                c.Tag = p.ID;
                clbProducts.Controls.Add(c);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (CheckBox c in clbProducts.Controls)
            {
                if (c.Checked)
                {
                    Order order = new Order();
                    order.ProductID = Convert.ToInt32(c.Tag);
                    order.CustomerID = currentCustomer.ID;
                    orderRepository.Add(order);
                    c.Checked = false;
                }
            }
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            EmployeeForm emp = new EmployeeForm(currentUser);
            this.Hide();
            emp.Show();
        }
    }
}
