using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;


namespace Application.GenreOperations.Queries
{
    public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mappper;

        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mappper = testFixture.Mapper;
        }
        [Fact]
        public void WhenGivenGenreIdIsNotinDb_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailQuery Query = new GetGenreDetailQuery(_context,_mappper);
            query.GenreId=0;

            FluentActions
               .Invoking(() => query.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı.");
        }

        [Fact]
        public void WhenGivenGenreIdIsinDB_InvalidOperationException_shouldBeReturn()
        {
           GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mappper);
           query.GenreId=1;

            var genre = _context.Genres.SingleOrDefaut(genre => genre.Id == genreDetailQuery.GenreId );
            genre.Should().NotBeNull();  
        }
    }
}