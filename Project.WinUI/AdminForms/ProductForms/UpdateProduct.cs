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
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
        }
        Product product;
        ProductRepository productRepository;
        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            this.Text = "Update Product Menu";
            LoadListBox();
        }

        private void LoadListBox()
        {
            lstProducts.DataSource = productRepository.GetActives();
            lstProducts.SelectedIndex = -1;
        }

        private void LstProducts_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex > -1)
            {
                product = lstProducts.SelectedItem as Product;
                txtProductName.Text = product.ProductName;
                txtProductDescription.Text = product.Description;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex > -1)
            {
                product.ProductName = txtProductName.Text;
                product.Description = txtProductDescription.Text;
                productRepository.Update(product);
                LoadListBox();
                ClearTextBoxes();
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex > -1)
            {
                productRepository.Delete(product);
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
            AddProduct atm = new AddProduct();
            atm.Show();
            this.Hide();
        }
    }
}
