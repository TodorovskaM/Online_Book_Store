using NUnit.Framework;
using BookStore.Services;
using FakeItEasy;
using BookStore.Repository;

namespace BookStore.Tests
{
    [TestFixture]
    public class BookServiceTests
    {
        private BookService sut;
        private IDbRepository repo;

        [SetUp]
        public void SetUp()
        {
            repo = A.Fake<IDbRepository>();

            sut = new BookService(repo);
        }
    }
}
