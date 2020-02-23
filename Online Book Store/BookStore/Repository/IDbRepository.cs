using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Repository
{
    public interface IDbRepository
    {
        bool AddABook(Book book);
        bool DeleteBook(int bookId);
        bool UpdateBook(int bookId, Book book);
        bool AddACategory(Category category);
        Book SelectBookByTitle(string title);
        Book SelectBookByAuthor(string author);
        Book SelectByCategory(string category);
        Customers GetCustomer(int customerId);
        bool AddACustomer(Customers customer);
        bool UpdateCustomerInfo(Customers customer);
        bool DeleteCustomer(int customerId);
        Book GetBook(int bookId);
        Customers GetCustomers(string username, string password);

    }
}
