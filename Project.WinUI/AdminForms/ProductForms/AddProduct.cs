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

namespace Project.WinUI.AdminForms.ProductForms
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
        }
        Product product;
        ProductRepository productRepository;

        private void AddProduct_Load(object sender, EventArgs e)
        {
            this.Text = "Add Product Menu";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            product = new Product(); ;
            product.ProductName = txtProductName.Text;
            product.Description = txtProductDescription.Text;
            productRepository.Add(product);
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
