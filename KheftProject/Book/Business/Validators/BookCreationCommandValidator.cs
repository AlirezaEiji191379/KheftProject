﻿using FluentValidation;
using KheftProject.Book.Business.Contracts.Commands;

namespace KheftProject.Book.Business.Validators;

internal class BookCreationCommandValidator : AbstractValidator<BookCreationCommand>
{
    public BookCreationCommandValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Invalid Price");
        RuleFor(x => x.BookName)
            .NotEmpty()
            .WithMessage("book name must have value");
        RuleFor(x => x.BookName)
            .MaximumLength(70)
            .WithMessage("book name has max length of 70");
        RuleFor(x => x.Description)
            .MaximumLength(900)
            .WithMessage("description name at most has 900 characters");
        RuleFor(x => x.BookOwner).SetValidator(new BookOwnerValidator());
    }
}