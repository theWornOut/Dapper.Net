using Dapper.Net.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Dapper.Net.Business
{
    class CustomerController
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);

        public IEnumerable<Customers> GetCustomersList()
        {
            IEnumerable<Customers> ordersList = _connection.Query<Customers>("select * from customers");
            return ordersList;
        }

        public Customers FindCustomer(object id)
        {
            return _connection.Query<Customers>("select * from customers where CustomerID = '" + id + "'").FirstOrDefault();
        }

        public void InsertCustomer(Customers customer)
        {
            _connection.Execute("insert into customers(CustomerID, CompanyName,ContactName,ContactTitle) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle); select * from customers", customer);
        }

        public void UpdateCustomer(Customers customer)
        {
            _connection.Execute("update customers set CustomerID = '" + customer.CustomerID + "', CompanyName = '" + customer.CompanyName + "', ContactName= '" + customer.ContactName + "', ContactTitle = '" + customer.ContactTitle + "' where CustomerID = '" + customer.CustomerID + "'");
        }

        public void DeleteCustomer(Customers customer)
        {
            _connection.Execute("delete from customers where CustomerID = '" + customer.CustomerID + "'");
        }
    }
}
