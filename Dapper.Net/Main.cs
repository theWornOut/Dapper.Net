using Dapper.Net.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dapper.Net
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private SqlConnection Connection()
        {
            return new SqlConnection("data source =.; database = Northwind; integrated security = true;");
        }

        private IEnumerable<Customers> GetCustomersList()
        {
            IEnumerable<Customers> ordersList = Connection().Query<Customers>("select * from customers");
            return ordersList;
        }

        private void InsertOrders(Customers customer)
        {
            Connection().Execute("insert into customers(CustomerID, CompanyName,ContactName,ContactTitle) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle); select * from customers", customer);
        }

        private void UpdateOrders(Customers customer)
        {
            Connection().Execute("update customers set CustomerID = @CustomerID, CompanyName = @CompanyName, ContactName= @ContactName, ContactTitle = @ContactTitle where CustomerID = @CustomerID", customer);
        }

        private void DeleteOrders(Customers customer)
        {
            Connection().Execute("delete from customers where CustomerID = @CustomerID", customer);
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
            dataGridView1.DataSource = GetCustomersList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.CustomerID = textBox1.Text;
            c.CompanyName = textBox2.Text;
            c.ContactName = textBox3.Text;
            c.ContactTitle = textBox4.Text;

            InsertOrders(c);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //UpdateOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DeleteOrders();
        }
    }
}
