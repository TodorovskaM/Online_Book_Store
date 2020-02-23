using BookStore.Models;
using System;
using BookStore.Repository;
using System.Collections.Generic;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IDbRepository repo;
        public BookService(IDbRepository repo)
        {
            this.repo = repo;
        }


        public bool AddABook(Book book)
        {
            if (book == null) return false;

            return repo.AddABook(book);
        }


        public bool DeleteBook(int bookId)
        {
            Book book = repo.GetBook(bookId);

            if (book == null) return true;

            return repo.DeleteBook(bookId);
        }

        public Book SelectBookByAuthor(string author)
        {
            return repo.SelectBookByAuthor(author);
        }

        public Book SelectBookByTitle(string title)
        {
            return repo.SelectBookByTitle(title);
        }


        public bool UpdateBook(int bookId, Book book)
        {
            return repo.UpdateBook(bookId, book);
        }

        public Book GetBook(int bookId)
        {
            return repo.GetBook(bookId);
        }


    }
}
