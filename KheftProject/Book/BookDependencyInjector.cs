using FluentValidation;
using KheftProject.Book.Business.Abstractions;
using KheftProject.Book.Business.Contracts.Commands;
using KheftProject.Book.Business.Job;
using KheftProject.Book.Business.Validators;
using KheftProject.Book.DataAccess.Repositories;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Book.Facade;
using KheftProject.Book.Facade.Abstractions;
using KheftProject.Core.DependencyInjection.Abstraction;

namespace KheftProject.Book;

public class BookDependencyInjector : IDependencyInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookMetaDataRepository, BookMetaDataRepository>();
        services.AddSingleton<IValidator<BookCreationCommand>, BookCreationCommandValidator>();
        services.AddScoped<IBookFacade, BookFacade>();
        services.AddScoped<IUnpaidBooksRemoverJob, UnpaidBooksRemoverJob>();
    }
}