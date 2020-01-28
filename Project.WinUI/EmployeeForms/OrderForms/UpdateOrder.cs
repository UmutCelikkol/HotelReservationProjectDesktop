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
    public partial class UpdateOrder : Form
    {
        public UpdateOrder(AppUser user, Customer customer)
        {
            InitializeComponent();
            currentUser = user;
            currentCustomer = customer;
            orderRepository = new OrderRepository();
        }
        AppUser currentUser;
        Customer currentCustomer;
        OrderRepository orderRepository;
        private void UpdateOrder_Load(object sender, EventArgs e)
        {
            this.Text = currentUser.UserName;
            foreach (Order o in orderRepository.Where(x => x.CustomerID == currentCustomer.ID))
            {
                CheckBox c = new CheckBox();
                c.Text = o.ToString();
                c.Tag = o.ProductID;
                clbProducts.Items.Add(c);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            foreach (CheckBox c in clbProducts.CheckedItems)
            {
                Order order = orderRepository.Select(x=>x.ProductID == Convert.ToInt32(c.Tag) && x.CustomerID == currentCustomer.ID) as Order;
                orderRepository.Delete(order);
                c.Checked = false;
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
