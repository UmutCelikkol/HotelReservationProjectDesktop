using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI.AdminForms.TypeForms
{
    public partial class UpdateType : Form
    {
        public UpdateType()
        {
            InitializeComponent();
            typeRepository = new TypeRepository();
        }
        MODEL.Entities.Type type;
        TypeRepository typeRepository;

        private void UpdateType_Load(object sender, EventArgs e)
        {
            this.Text = "Update Type Menu";
            LoadListBox();
        }

        void LoadListBox()
        {
            lstTypes.DataSource = typeRepository.GetActives();
            lstTypes.SelectedIndex = -1;
        }

        private void Lsttypes_Click(object sender, EventArgs e)
        {
            if (lstTypes.SelectedIndex > -1)
            {
                type = lstTypes.SelectedItem as MODEL.Entities.Type;
                txtTypeName.Text = type.TypeName;
                txtTypeDescription.Text = type.Description;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstTypes.SelectedIndex > -1)
            {
                type.TypeName = txtTypeName.Text;
                type.Description = txtTypeDescription.Text;
                typeRepository.Update(type);
                LoadListBox();
                ClearTextBoxes();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstTypes.SelectedIndex > -1)
            {
                typeRepository.Delete(type);
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
            AddType atm = new AddType();
            atm.Show();
            this.Hide();
        }
    }
}
