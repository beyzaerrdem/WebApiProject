using FluentValidation;
using WebApiProject.Services.BookOperations;

namespace WebApiProject.Validator
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator() 
        {
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.PageCount).GreaterThan(0);
            RuleFor(x => x.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date); //bugünden daha eski bir tarih olmalı
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}
