using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BookStore.Models;
using BookStore.Services;
using BookStore.Validation;
using System.Net.Http;
using System.Web.Http;
using FluentValidation;

namespace BookStore.Api.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookService service;

        public BooksController(IBookService service)
        {
            this.service = service;
        }

        // GET: api/books/2
        public IHttpActionResult Get(int id)
        {
            var book = service.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/books
        public HttpResponseMessage Post(Book book)
        {
            Book_Validation validator = new Book_Validation();
            var result = validator.Validate(book);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (service.AddABook(book))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        // PUT: api/books/9
        public IHttpActionResult Put(int bookId, Book book)
        {
            Book_Validation validator = new Book_Validation();
            var result = validator.Validate(book);

            if (!result.IsValid) return BadRequest();

            try
            {
                if (service.UpdateBook(bookId, book))
                {
                    return Ok();
                }

                return InternalServerError();
            }
            catch (ApplicationException)
            {
                return NotFound();
            }
        }

        // DELETE: api/books/7
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (service.DeleteBook(id))
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }

    }
}
