using FluentValidation;
using KheftProject.Payment.Business.Contracts.Commands;

namespace KheftProject.Payment.Business.Validators;

public class PayBookCommandValidator : AbstractValidator<PayBookCommand>
{
    public PayBookCommandValidator()
    {
        RuleFor(x => x.BookId)
            .NotEmpty()
            .WithMessage("book id must not be empty!");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("the price must be greater than zero");
    }
}