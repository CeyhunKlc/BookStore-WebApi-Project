using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mappper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mappper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExitBookTitleIsGivenException_ShouldBeReturn()
        {
            //arrange (Hazırlık)
            var book = new Book() { Title = "Test_WhenAlreadyExitBookTitleIsGivenException_ShouldBeReturn", PageCount = 100, PublisDate = new System.DateTime(1990, 01, 10), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mappper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //act (çalıştırma) & Assert (Doğrulama)
            FluentActions
               .Invoking(()=> command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Zaten Mevcut");
        }
    }
}