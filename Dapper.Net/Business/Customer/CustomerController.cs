using Dapper.Net.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Dapper.Net.Business
{
    public class CustomerController : ICustomerController
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabases"].ConnectionString);
        /// <summary>
        /// Müşterilerin listelendiği metod.
        /// </summary>
        /// <returns>IEnumerable tipinde müşteriler listesi geriye döner.</returns>
        public IEnumerable<Customers> GetCustomersList()
        {
            IEnumerable<Customers> ordersList = _connection.Query<Customers>("select * from customers;");
            return ordersList;
        }

        /// <summary>
        /// ID'si bilinen müşteriyi bulmak için kullanılan metod.
        /// </summary>
        /// <param name="id">Müşteriye ait ID</param>
        /// <returns>ID'si verilen müşteri, Customers tipinde geriye döner.</returns>
        public Customers FindCustomer(object id)
        {
            return _connection.Query<Customers>("select * from customers where CustomerID = '" + id + "'; select * from customers;").FirstOrDefault();
        }

        /// <summary>
        /// Yeni müşteri kaydetmek için kullanılan metod.
        /// </summary>
        /// <param name="customer">Customers tipinde bir customer</param>
        public void InsertCustomer(Customers customer)
        {
            _connection.Execute("insert into customers(CustomerID, CompanyName,ContactName,ContactTitle) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle); select * from customers;", customer);
        }

        /// <summary>
        /// Mevcut müşteriyi güncellemek için kullanılan bir metod.
        /// </summary>
        /// <param name="customer">Customers tipinde bir customer</param>
        public void UpdateCustomer(Customers customer)
        {
            _connection.Execute("update customers set CompanyName = '" + customer.CompanyName + "', ContactName= '" + customer.ContactName + "', ContactTitle = '" + customer.ContactTitle + "' where CustomerID = '" + customer.CustomerID + "'; select * from customers;");
        }

        /// <summary>
        /// Mevcut müşteriyi silmek için kullanılan bir metod.
        /// </summary>
        /// <param name="customer">Customers tipinde bir customer</param>
        public void DeleteCustomer(Customers customer)
        {
            _connection.Execute("delete from customers where CustomerID = '" + customer.CustomerID + "'; select * from customers;");
        }
    }
}
