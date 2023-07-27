using FluentValidation;
using WebApiProject.BookOperations;

namespace WebApiProject.Validator
{
    public class GetByIdValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdValidator() 
        {
            RuleFor(x => x.BookId).GreaterThan(0);
        }
    }
}
