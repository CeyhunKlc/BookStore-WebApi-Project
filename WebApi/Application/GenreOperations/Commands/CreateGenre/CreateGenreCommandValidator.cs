using FluentValidation;
using webApi.Application.GenreOperations.CreateGenre;

namespace webApi.Application.GenreOperations.createGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}