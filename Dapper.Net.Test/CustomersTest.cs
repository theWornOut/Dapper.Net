using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.SqlClient;
using Dapper.Net.Models;
using System.Collections.Generic;
using System.Linq;

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
        public void FindCustomer()
        {
            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);
            _connection.Query<Customers>("select * from customers where CustomerID = '" + "Aaa" + "'").FirstOrDefault();
        }

        [TestMethod]
        public void InsertCustomer()
        {
            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);
            Customers customer = new Customers();
            customer.CustomerID = "Aaa";
            customer.CompanyName = "as";
            customer.ContactName = "zx";
            customer.ContactTitle = "vv";

            _connection.Execute("insert into customers(CustomerID, CompanyName,ContactName,ContactTitle) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle);", customer);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);
            Customers customer = new Customers();
            customer.CustomerID = "Aaa";
            customer.CompanyName = "CompName1";
            customer.ContactName = "ContName1";
            customer.ContactTitle = "ContTitle1";

            _connection.Execute("update customers set CompanyName = '" + customer.CompanyName + "', ContactName= '" + customer.ContactName + "', ContactTitle = '" + customer.ContactTitle + "' where CustomerID = '" + customer.CustomerID + "'");
        }

        [TestMethod]
        public void DeleteCustomer()
        {
            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);
            Customers customer = new Customers();
            customer.CustomerID = "Aaa";
            _connection.Execute("delete from customers where CustomerID = '" + customer.CustomerID + "'");
        }
    }
}
