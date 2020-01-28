using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using Project.WinUI.CustomerForms.OrderForms;
using Project.WinUI.CustomerForms.ReservationForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI.CustomerForms
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm(AppUser user)
        {
            InitializeComponent();
            currentUser = user;
            customerRepository = new CustomerRepository();
            reservationRepository = new ReservationRepository();
        }
        AppUser currentUser;
        Customer customer;
        CustomerRepository customerRepository;
        ReservationRepository reservationRepository;
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            this.Text = currentUser.Profile.FirstName;
            LoadListBox();
        }

        void LoadListBox()
        {
            lstCustomers.DataSource = customerRepository.GetActives();
            lstCustomers.SelectedIndex = -1;
        }

        private void BtnAddReservation_Click(object sender, EventArgs e)
        {
            AddReservation addReservation = new AddReservation(currentUser, customer);
            this.Hide();
            addReservation.Show();

        }

        private void LstCustomers_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex > -1)
            {
                customer = lstCustomers.SelectedItem as Customer;
                double borc = 0;

                foreach (Reservation r in customer.Reservations)
                {
                    borc += Convert.ToDouble(r.Amount);

                }
                lblBorc.Text = $"Customer's Cost Amount: { borc.ToString():C2}";
            }
        }

        private void BtnAddOrder_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder(currentUser, customer);
            this.Hide();
            addOrder.Show();
        }

        private void BtnUpdateOrder_Click(object sender, EventArgs e)
        {
            UpdateOrder updateOrder = new UpdateOrder(currentUser, customer);
            this.Hide();
            updateOrder.Show();
        }

        private void BtnUpdateReservation_Click(object sender, EventArgs e)
        {
            UpdateReservation updateReservation = new UpdateReservation(currentUser, customer);
            this.Hide();
            updateReservation.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
              if (lstCustomers.SelectedIndex > -1)
            {
                customer = lstCustomers.SelectedItem as Customer;
                double borc = 0;

                foreach (Reservation r in customer.Reservations)
                {
                    reservationRepository.Delete(r);
                    r.Amount = 0;
                }
                lblBorc.Text = $"Customer's Cost Amount: { borc.ToString():C2}";
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            this.Hide();
            lgn.Show();
        }
    }
}
