using Dapper.Net.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

//Değiştirilecek. Dinamik yapı kazandırılmalı.
namespace Dapper.Net
{
    public partial class Main : Form
    {
        string sConn = "";
        public Main()
        {
            InitializeComponent();
            sConn = ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString;
        }

        private IEnumerable<Customers> GetCustomersList()
        {
            using (var connection = new SqlConnection(sConn))
            {
                IEnumerable<Customers> ordersList = connection.Query<Customers>("select * from customers");
                return ordersList;
            }
        }

        private void InsertCustomer(Customers customer)
        {
            using (var connection = new SqlConnection(sConn))
            {
                connection.Execute("insert into customers(CustomerID, CompanyName,ContactName,ContactTitle) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle); select * from customers", customer);
            }
        }

        private void UpdateCustomer(Customers customer)
        {
            using (var connection = new SqlConnection(sConn))
            {
                connection.Execute("update customers set CustomerID = '" + customer.CustomerID + "', CompanyName = '" + customer.CompanyName + "', ContactName= '" + customer.ContactName + "', ContactTitle = '" + customer.ContactTitle + "' where CustomerID = '" + customer.CustomerID + "'");
            }
        }

        private void DeleteCustomer(Customers customer)
        {
            using (var connection = new SqlConnection(sConn))
            {
                connection.Execute("delete from customers where CustomerID = '" + customer.CustomerID + "'");
            }
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

            InsertCustomer(c);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(sConn))
            {
                var c = connection.Query<Customers>("select * from customers where CustomerID = '" + textBox1.Text + "'").FirstOrDefault();
                c.CustomerID = textBox1.Text;
                c.CompanyName = textBox2.Text;
                c.ContactName = textBox3.Text;
                c.ContactTitle = textBox4.Text;

                UpdateCustomer(c);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(sConn))
            {
                var c = connection.Query<Customers>("select * from customers where CustomerID = '" + textBox1.Text + "'").FirstOrDefault();

                DeleteCustomer(c);
            }
        }
    }
}
