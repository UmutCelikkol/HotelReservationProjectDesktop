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
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
            typeRepository = new TypeRepository();
            roomRepository = new RoomRepository();
        }
        MODEL.Entities.Type type;
        RoomRepository roomRepository;
        TypeRepository typeRepository;

        private void AddRoom_Load(object sender, EventArgs e)
        {
            this.Text = "Add Room Menu";
            LoadListBox();
        }
        void LoadListBox()
        {
            lstTypes.DataSource = typeRepository.GetActives();
            lstTypes.SelectedIndex = -1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (lstTypes.SelectedIndex > -1)
            {
                Room room = new Room();
                room.Number = txtNumber.Text;
                room.Block = txtBlock.Text;
                room.Floor = Convert.ToInt32(txtFloor.Text);
                room.TypeID = type.ID;
                room.Price = Convert.ToDecimal(txtPrice.Text);
                roomRepository.Add(room);
                LoadListBox();
                ClearTextBoxes();
            }
        }
        private void LstTypes_Click(object sender, EventArgs e)
        {
            if (lstTypes.SelectedIndex > -1)
            {
                type = lstTypes.SelectedItem as MODEL.Entities.Type;
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

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm adm = new AdminForm();
            this.Hide();
            adm.Show();
        }
    }
}
