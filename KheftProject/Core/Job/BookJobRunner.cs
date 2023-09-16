using KheftProject.Book.Business.Abstractions;

namespace KheftProject.Core.Job;

public class BookJobRunner : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    
    public BookJobRunner(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var deactivationJob = scope.ServiceProvider.GetRequiredService<IUnpaidBooksRemoverJob>();
                await deactivationJob.RemoveUnpaidBooks();
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
            catch (Exception exception)
            {
            }
        }
    }
}