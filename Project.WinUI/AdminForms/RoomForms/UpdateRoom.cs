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

namespace Project.WinUI.AdminForms.RoomForms
{
    public partial class UpdateRoom : Form
    {
        public UpdateRoom()
        {
            InitializeComponent();
            roomRepository = new RoomRepository();
            typeRepository = new TypeRepository();
        }
        Room room;
        MODEL.Entities.Type type;
        RoomRepository roomRepository;
        TypeRepository typeRepository;

        private void UpdateRoom_Load(object sender, EventArgs e)
        {
            this.Text = "Update Room Menu";
            LoadListBox();
        }

        void LoadListBox()
        {
            lstRooms.DataSource = roomRepository.GetActives();
            lstTypes.DataSource = typeRepository.GetActives();
            lstRooms.SelectedIndex = -1;
            lstTypes.SelectedIndex = -1;
        }

        private void LstRooms_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedIndex > -1)
            {
                room = lstRooms.SelectedItem as Room;
                txtNumber.Text = room.Number;
                txtBlock.Text = room.Block;
                txtFloor.Text = room.Floor.ToString();
                txtPrice.Text = room.Price.ToString();
                lstTypes.SelectedItem = (MODEL.Entities.Type)room.Type;
            }
        }

        private void LstTypes_Click(object sender, EventArgs e)
        {
            if (lstTypes.SelectedIndex > -1)
            {
                type = lstTypes.SelectedItem as MODEL.Entities.Type;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedIndex > -1 && lstTypes.SelectedIndex > -1)
            {
                room.Number = txtNumber.Text;
                room.Block = txtBlock.Text;
                room.Floor = Convert.ToInt32(txtFloor.Text);
                room.TypeID = type.ID;
                room.Price = Convert.ToDecimal(txtPrice.Text);
                roomRepository.Update(room);
                LoadListBox();
                ClearTextBoxes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedIndex > -1 && lstTypes.SelectedIndex > -1)
            {
                roomRepository.Delete(room);
                ClearTextBoxes();
                LoadListBox();
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
            AddRoom atm = new AddRoom();
            atm.Show();
            this.Hide();
        }
    }
}
