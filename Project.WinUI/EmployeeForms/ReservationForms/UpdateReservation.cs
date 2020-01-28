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

namespace Project.WinUI.CustomerForms.ReservationForms
{
    public partial class UpdateReservation : Form
    {
        public UpdateReservation(AppUser user, Customer customer)
        {
            InitializeComponent();
            currentUser = user;
            currentCustomer = customer;
            customerRepository = new CustomerRepository();
            reservationRepository = new ReservationRepository();
        }
        AppUser currentUser;
        Reservation reservation;
        Customer currentCustomer;
        CustomerRepository customerRepository;
        ReservationRepository reservationRepository;

        private void UpdateReservation_Load(object sender, EventArgs e)
        {
            this.Text = currentUser.UserName;
            dtpStartDate.Enabled = dtpFinishDate.Enabled = false;
            LoadListBox();
        }

        void LoadListBox()
        {
            lstReservations.DataSource = reservationRepository.Where(x => x.CustomerID == currentCustomer.ID && x.Status != MODEL.Enums.DataStatus.Deleted);
            lstReservations.SelectedIndex = -1;
        }


        private void LstReservations_Click(object sender, EventArgs e)
        {
            if (lstReservations.SelectedIndex > -1)
            {
                reservation = lstReservations.SelectedItem as Reservation;
                dtpStartDate.Value = (DateTime)(lstReservations.SelectedItem as Reservation).StartDate;
                dtpFinishDate.Value = (DateTime)(lstReservations.SelectedItem as Reservation).FinishDate;
                dtpStartDate.Enabled = dtpFinishDate.Enabled = true;
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstReservations.SelectedIndex > -1)
            {
                reservation.StartDate = dtpStartDate.Value;
                reservation.FinishDate = dtpFinishDate.Value;
                reservationRepository.Update(reservation);
                MessageBox.Show($"Reservation that have a Reservation ID:{reservation.ID} has been updated!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            reservationRepository.Delete(reservation);
            LoadListBox();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            EmployeeForm emp = new EmployeeForm(currentUser);
            this.Hide();
            emp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddReservation adr = new AddReservation(currentUser,currentCustomer);
            this.Hide();
            adr.Show();

        }
    }
}
