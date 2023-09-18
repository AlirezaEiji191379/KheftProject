using FluentValidation;
using KheftProject.Core.DependencyInjection.Abstraction;
using KheftProject.Payment.Business.Contracts.Commands;
using KheftProject.Payment.Business.Validators;
using KheftProject.Payment.DataAccess.Repositories;
using KheftProject.Payment.DataAccess.Repositories.Abstraction;

namespace KheftProject.Payment;

public class PaymentDependencyInjection : IDependencyInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddSingleton<IValidator<PayBookCommand>, PayBookCommandValidator>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
    }
}