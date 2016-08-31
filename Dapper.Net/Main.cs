using Dapper.Net.Models;
using System;
using System.Windows.Forms;
using Dapper.Net.Business;

namespace Dapper.Net
{
    public partial class Main : Form
    {
        CustomerController customerController = new CustomerController();
        public Main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["CustomerID"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["CompanyName"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["ContactName"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["ContactTitle"].Value.ToString();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customerController.GetCustomersList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.CustomerID = textBox1.Text;
            c.CompanyName = textBox2.Text;
            c.ContactName = textBox3.Text;
            c.ContactTitle = textBox4.Text;

            customerController.InsertCustomer(c);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customers c = customerController.FindCustomer(textBox1.Text);
            customerController.UpdateCustomer(c);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customers c = customerController.FindCustomer(textBox1.Text);
            customerController.DeleteCustomer(c);
        }
    }
}
