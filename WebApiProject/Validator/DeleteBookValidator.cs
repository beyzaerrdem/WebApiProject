using FluentValidation;
using WebApiProject.BookOperations;

namespace WebApiProject.Validator
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator() 
        {
            RuleFor(x => x.BookId).GreaterThan(0);
        }
    }
}
