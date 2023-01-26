using FluentValidation;

namespace WebApi.Application.AuthorOperation.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        { 
            RuleFor(command => command.AuthorId).GreaterThan(0).NotEmpty();
        }
        
    }
}        