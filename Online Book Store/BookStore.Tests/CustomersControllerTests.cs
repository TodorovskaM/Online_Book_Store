using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Services;
using BookStore.Models;
using BookStore.Api.Controllers;
using System.Web.Http.Results;
using FakeItEasy;

namespace BookStore.Tests
{
    [TestFixture]
    public class CustomersControllerTests
    {
        private CustomersController sut;
        private ICustomersService service;

        [SetUp]
        public void SetUp()
        {
            service = A.Fake<ICustomersService>();

            sut = new CustomersController(service);
        }

        [Test]
        public void GetCustomer_when_product_found_return_ok()
        {
            // Arrange
            A.CallTo(() => service.GetCustomer(A<int>.Ignored)).Returns(new Customers() { CustomerId = 1 });

            // Act
            var result = sut.Get(1);

            // Assert
            var response = result as OkNegotiatedContentResult<Customers>;
            Assert.IsNotNull(response);
            var customer = response.Content;
            Assert.AreEqual(1, customer.CustomerId);
        }
    }
}
