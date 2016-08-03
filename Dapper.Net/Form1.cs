using Dapper.Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dapper.Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetOrdersList();
        }

        private SqlConnection Connection()
        {
            return new SqlConnection("data source =.; database = Northwind; integrated security = true;");
        }

        private void GetOrdersList()
        {
            IEnumerable<Orders> ordersList = Connection().Query<Orders>("select * from orders");
            dataGridView1.DataSource = ordersList;
        }
    }
}
