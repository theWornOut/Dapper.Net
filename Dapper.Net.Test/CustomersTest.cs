using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.SqlClient;
using Dapper.Net.Models;
using System.Collections.Generic;

namespace Dapper.Net.Test
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void GetCustomersList()
        {
            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);
            IEnumerable<Customers> ordersList = _connection.Query<Customers>("select * from customers");
        }

        [TestMethod]
        public void InsertCustomer()
        {
            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);
            Customers c = new Customers();
            c.CustomerID = "Aaa";
            c.CompanyName = "as";
            c.ContactName = "zx";
            c.ContactTitle = "vv";

            _connection.Execute("insert into customers(CustomerID, CompanyName,ContactName,ContactTitle) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle);", c);
        }

        [TestMethod]
        public void UpdateCustomer()
        {

        }
    }
}
