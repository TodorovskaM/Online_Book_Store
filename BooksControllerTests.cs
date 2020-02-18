using NUnit.Framework;
using BookStore.Services;
using BookStore.Models;
using BookStore.Api.Controllers;
using System.Web.Http.Results;
using FakeItEasy;

namespace BookStore.Tests
{
    [TestFixture]
    public class BooksControllerTests
    {
        private BooksController sut;
        private IBookService service;

        [SetUp]
        public void SetUp()
        {
            service = A.Fake<IBookService>();

            sut = new BooksController(service);
        }

        [Test]
        public void GetBook_when_product_found_return_ok()
        {
            // Arrange
            A.CallTo(() => service.GetBook(A<int>.Ignored)).Returns(new Book() { BookId = 1 });

            // Act
            var result = sut.Get(1);

            // Assert
            var response = result as OkNegotiatedContentResult<Book>;
            Assert.IsNotNull(response);
            var book = response.Content;
            Assert.AreEqual(1, book.BookId);
        }

        [Test]
        public void GetProduct_when_product_not_found_return_not_found()
        {
            // Arrange
            A.CallTo(() => service.GetBook(A<int>.Ignored)).Returns(null);

            // Act
            var result = sut.Get(1);

            // Assert
            var response = result as System.Web.Http.Results.NotFoundResult;
            Assert.IsNotNull(response);
        }
    }
}
