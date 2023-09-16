using FluentValidation;
using KheftProject.Book.Business.Contracts.Commands;

namespace KheftProject.Book.Business.Validators;

public class BookOwnerValidator : AbstractValidator<BookOwner>
{
    public BookOwnerValidator()
    {
        RuleFor(x => x.TelegramUsername)
            .NotEmpty()
            .WithMessage("empty or null Telegram Username is not allowed!");

        RuleFor(x => x.FullName)
            .MaximumLength(70)
            .WithMessage("the fullname length must be at most 70 characters");
        RuleFor(x => x.TelegramSerialId)
            .NotEmpty()
            .WithMessage("the telegram serial id must be provided!");
    }
}