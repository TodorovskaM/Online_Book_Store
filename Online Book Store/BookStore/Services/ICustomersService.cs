using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.DBAccess;

namespace BookStore.Services
{
    public interface ICustomersService
    {
        Customers GetCustomer(int customerId);
        bool AddACustomer(Customers customer);
        bool UpdateCustomerInfo(Customers customer);
        bool DeleteCustomer(int customerId);
        Customers ValidateLogin(string username, string password);
    }
}
