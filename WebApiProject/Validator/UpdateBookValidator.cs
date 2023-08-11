using FluentValidation;
using WebApiProject.Services.BookOperations;

namespace WebApiProject.Validator
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator() 
        {
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
