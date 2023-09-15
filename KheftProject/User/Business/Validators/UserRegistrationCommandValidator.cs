using FluentValidation;
using KheftProject.User.Business.Contracts.Commands;
using Microsoft.AspNetCore.Identity;

namespace KheftProject.User.Business.Validators;

public class UserRegistrationCommandValidator : AbstractValidator<UserRegistrationCommand>
{
    public UserRegistrationCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is Telegram Id and must have value!");
        RuleFor(x => x.TelegramUsername)
            .NotEmpty()
            .WithMessage("empty or null Telegram Username is not allowed!");
        When(x => !string.IsNullOrEmpty(x.PhoneNumber), () =>
        {
            RuleFor(x => x.PhoneNumber)
                .Length(11)
                .Matches(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$")
                .WithMessage("invalid Phone Number");
        });
        When(x => !string.IsNullOrEmpty(x.FullName), () =>
        {
            RuleFor(x => x.FullName)
                .MaximumLength(70)
                .WithMessage("the fullname length must be at most 70 characters");
        });
    }
}