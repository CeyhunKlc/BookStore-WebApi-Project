using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.GenreOperations.DeleteGenre;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.GenreOperations.DeleteGenre.DeleteGenreCommand;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        

        public void WhenInvalidGenreIdisGiven_Validator_ShouldBeReturnErrors(int GenreId)
        {
            
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.genreId = genreid;
            
            DeleteGenreCommandValidator validations = new DeleteGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        } 
       

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
    
        public void WhenInvalidGenreIdisGiven_Validator_ShouldBeReturnErrors(int GenreId)
        {
            
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.genreId = genreid;
            
            DeleteGenreCommandValidator validations = new DeleteGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        } 
    }
}       