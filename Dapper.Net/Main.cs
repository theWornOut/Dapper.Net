using Dapper.Net.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        private IEnumerable<Categories> GetCategoriesList()
        {
            IEnumerable<Categories> categoriesList = Connection().Query<Categories>("select * from Categories");
            return categoriesList;
        }

        private void InsertOrders(Categories customer)
        {
            Connection().Execute("insert into categories(CategoryID, CategoryName,Description,Picture) VALUES (@CategoryID, @CategoryName, @Description, @Picture); select * from category", customer);
        }

        private void UpdateOrders(Categories customer)
        {
            Connection().Execute("update categories set CategoryID = @CategoryID, CategoryName = @CategoryName, Description = @Description, Picture = @Picture where CustomerID = @CategoryID", customer);
        }

        private void DeleteOrders(Categories customer)
        {
            Connection().Execute("delete from categories where CategoryID = @CategoryID", customer);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["CategoryID"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["CategoryName"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["Picture"].Value.ToString();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetCategoriesList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();
            c.CategoryName = textBox2.Text;
            c.Description = textBox3.Text;
            c.Picture = null;

            InsertOrders(c);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var customer = (from x in GetCategoriesList() where x.CategoryID == textBox1.Text select x).FirstOrDefault();
            //UpdateOrders(customer);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DeleteOrders();
        }
    }
}
