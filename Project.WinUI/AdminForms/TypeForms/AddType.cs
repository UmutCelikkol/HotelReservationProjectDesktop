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
    public partial class AddType : Form
    {
        public AddType()
        {
            InitializeComponent();
            typeRepository = new TypeRepository();
        }
        MODEL.Entities.Type type;
        TypeRepository typeRepository;

        private void AddType_Load(object sender, EventArgs e)
        {
            this.Text = "Add Type Menu";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            type = new MODEL.Entities.Type();
            type.TypeName = txtTypeName.Text;
            type.Description = txtTypeDescription.Text;
            typeRepository.Add(type);
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

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm adm = new AdminForm();
            this.Hide();
            adm.Show();
        }
    }
}
