using FluentValidation;

namespace WebApi.BookOperations.CreateBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            
        }
    }
}