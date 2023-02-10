using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.GenreOperations.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.GenreOperations.CreateGenre.CreateGenreCommand;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("a b")]
        [InlineData("a")]
        [InlineData("ab")]

        public void WhenInvalidInputsGiven_Validator_ShouldBeReturnErrors(String Name)
        {
            
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel(){Name = name};
            
            CreateGenreCommandValidator validations = new CreateGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        } 
       

        [Theory]
        [InlineData("abcde")]
        [InlineData("abc")]
        [InlineData("ab")]
        [InlineData("querty")]

        
        public void WhenInvalidInputsGiven_Validator_ShouldBeReturn(String Name)
        {
            
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel(){Name = name};
            
            CreateGenreCommandValidator validations = new CreateGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        } 
    }
}       