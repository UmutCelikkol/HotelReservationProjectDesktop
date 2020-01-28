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
    public partial class AddReservation : Form
    {
        public AddReservation(AppUser user, Customer customer)
        {
            InitializeComponent();
            currentUser = user;
            currentCustomer = customer;
            reservationRepository = new ReservationRepository();
            roomRepository = new RoomRepository();
        }
        AppUser currentUser;
        Customer currentCustomer;
        Room room;
        ReservationRepository reservationRepository;
        RoomRepository roomRepository;
        private void AddReservation_Load(object sender, EventArgs e)
        {
            this.Text = currentUser.UserName;
            dtpStartDate.Enabled = dtpFinishDate.Enabled = false;
            LoadListBox();
        }

        void LoadListBox()
        {
            lstRooms.DataSource = roomRepository.GetActives();
            lstRooms.SelectedIndex = -1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            if (lstRooms.SelectedIndex > -1)
            {
                if (dtpFinishDate.Value > dtpStartDate.Value)
                {
                    Reservation reservation = new Reservation();
                    reservation.StartDate = dtpStartDate.Value;
                    reservation.FinishDate = dtpFinishDate.Value;
                    reservation.CustomerID = currentCustomer.ID;
                    reservation.RoomID = room.ID;
                    reservation.Amount = Convert.ToDecimal(room.Price * Convert.ToDecimal((dtpFinishDate.Value - dtpStartDate.Value).TotalDays));
                    reservationRepository.Add(reservation);
                    LoadListBox();
                }
            }

        }

        private void LstRooms_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedIndex > -1)
            {
                room = lstRooms.SelectedItem as Room;
                dtpStartDate.Enabled = dtpFinishDate.Enabled = true;
            }
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            EmployeeForm emp = new EmployeeForm(currentUser);
            this.Hide();
            emp.Show();
        }

        private void lstRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
