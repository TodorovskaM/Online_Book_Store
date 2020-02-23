using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{
    public interface IBookService
    {
        bool AddABook(Book book);
        bool DeleteBook(int bookId);
        bool UpdateBook(int bookId, Book book);
        Book SelectBookByTitle(string title);
        Book SelectBookByAuthor(string author);
        Book GetBook(int bookId);
    }
}
