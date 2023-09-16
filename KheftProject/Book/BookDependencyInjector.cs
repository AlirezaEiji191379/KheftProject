using FluentValidation;
using KheftProject.Book.Business.Contracts.Commands;
using KheftProject.Book.Business.Validators;
using KheftProject.Book.DataAccess.Repositories;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.DependencyInjection.Abstraction;

namespace KheftProject.Book;

public class BookDependencyInjector : IDependencyInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddSingleton<IValidator<BookCreationCommand>, BookCreationCommandValidator>();
    }
}