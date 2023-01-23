using FluentValidation;


namespace webApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(3).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }
}