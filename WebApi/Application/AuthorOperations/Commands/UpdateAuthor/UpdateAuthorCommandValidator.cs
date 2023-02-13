using FluentValidation;
using WebApi.BookOperations.UpdateAuthor;

namespace webApi.Application.AuthorOperations.CreateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {

        public UpdateAuthorCommandValidator()
        { 
            RuleFor(Command => Command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command=> command.Model.Surname).NotEmpty().MinimumLength(3);
             
        }
    }    
}        