using FluentValidation;
using KheftProject.User.Business.Contracts.Commands;
using Microsoft.AspNetCore.Identity;

namespace KheftProject.User.Business.Validators;

public class UserRegistrationCommandValidator : AbstractValidator<UserRegistrationCommand>
{
    public UserRegistrationCommandValidator()
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