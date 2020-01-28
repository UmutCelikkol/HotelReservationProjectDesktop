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

namespace Project.WinUI.AdminForms.AttributeForms
{
    public partial class AddAttribute : Form
    {
        public AddAttribute()
        {
            InitializeComponent();
            attributeRepository = new AttributeRepository();
           
        }
        MODEL.Entities.Attribute attribute;
        AttributeRepository attributeRepository;
        AppUser user;
  
        private void AddAttribute_Load(object sender, EventArgs e)
        {
            this.Text = "Add Attribute Menu";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            attribute = new MODEL.Entities.Attribute();
            attribute.AttributeName = txtAttributeName.Text;
            attribute.Description = txtAttributeDescription.Text;
            attributeRepository.Add(attribute);
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
            AdminForm adminForm = new AdminForm();
            this.Hide();
            adminForm.Show();
        }
    }
}
