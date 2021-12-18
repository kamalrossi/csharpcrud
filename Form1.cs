using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCSHARPCRUD
{
    public partial class Form1 : Form
    {
        ProductRepo productRepo = new ProducRepo();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productRepo.GetAll();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAddFN.Text) && !string.IsNullOrEmpty(txtAddLN.Text))
            {
                productRepo.Add(new Product
                {
                    name = txtAddFN.Text,
                    description = txtAddLN.Text,
                });
                txtAddFN.Text = string.Empty;
                txtAddLN.Text = string.Empty;
                dataGridView1.DataSource = productRepo.GetAll();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var product = (Product)row.DataBoundItem;
                txtId.Text = product.Id.ToString();
                txtFN.Text = product.name;
                txtLN.Text = product.description;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text))
            {
                productRepo.Update(new Product
                {
                    Id = int.Parse(txtId.Text),
                    FirstName = txtFN.Text,
                    LastName = txtLN.Text
                });
                dataGridView1.DataSource = productRepo.GetAll();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text))
            {
                productRepo.Delete(int.Parse(txtId.Text));
                txtId.Text = string.Empty;
                txtFN.Text = string.Empty;
                txtLN.Text = string.Empty;
                dataGridView1.DataSource = productRepo.GetAll();
            }
        }
    }
}