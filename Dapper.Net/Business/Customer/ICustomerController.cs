using System.Collections.Generic;
using Dapper.Net.Models;

namespace Dapper.Net.Business
{
    public interface ICustomerController
    {
        void DeleteCustomer(Customers customer);
        Customers FindCustomer(object id);
        IEnumerable<Customers> GetCustomersList();
        void InsertCustomer(Customers customer);
        void UpdateCustomer(Customers customer);
    }
}