using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;

namespace BookStore.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IDbRepository repo;
        public CustomersService(IDbRepository repo)
        {
            this.repo = repo;
        }

        public bool AddACustomer(Customers customer)
        {
            if (customer == null) return false;

            return repo.AddACustomer(customer);
        }

        public Customers GetCustomer(int customerId)
        {
            var customer = repo.GetCustomer(customerId);
            return customer;
        }

        public bool UpdateCustomerInfo(Customers customer)
        {
            if (customer == null) return false;

            return repo.UpdateCustomerInfo(customer);
        }

        public bool DeleteCustomer(int customerId)
        {
            Customers customer = repo.GetCustomer(customerId);

            if (customer == null) return true;

            return repo.DeleteCustomer(customerId);
        }

        public Customers ValidateLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return null;

            return repo.GetCustomers(username, password);
        }
    }
}
