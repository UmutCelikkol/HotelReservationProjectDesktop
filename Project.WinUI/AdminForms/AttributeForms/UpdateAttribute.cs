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
    public partial class UpdateAttribute : Form
    {
        public UpdateAttribute()
        {
            InitializeComponent();
            attributeRepository = new AttributeRepository();
        }
        MODEL.Entities.Attribute attribute;
        AttributeRepository attributeRepository;
        AppUser user;

        private void UpdateAttribute_Load(object sender, EventArgs e)
        {
            this.Text = "Update Attribute Menu";
            LoadListBox();
        }

        void LoadListBox()
        {
            lstAttributes.DataSource = attributeRepository.GetActives();
            lstAttributes.SelectedIndex = -1;
        }

        private void LstAttributes_Click(object sender, EventArgs e)
        {
            if (lstAttributes.SelectedIndex > -1)
            {
                attribute = lstAttributes.SelectedItem as MODEL.Entities.Attribute;
                txtAttributeName.Text = attribute.AttributeName;
                txtAttributeDescription.Text = attribute.Description;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstAttributes.SelectedIndex > -1)
            {
                attribute.AttributeName = txtAttributeName.Text;
                attribute.Description = txtAttributeDescription.Text;
                attributeRepository.Update(attribute);
                LoadListBox();
                ClearTextBoxes();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstAttributes.SelectedIndex > -1)
            {
                attributeRepository.Delete(attribute);
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

        private void button1_Click(object sender, EventArgs e)
        {
            AddAttribute att = new AddAttribute();
            this.Hide();
            att.Show();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            AdminForm adm = new AdminForm();
            this.Hide();
            adm.Show();
        }
    }
}
