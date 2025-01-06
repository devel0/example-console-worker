
namespace ExampleConsoleWorker;

public class Worker : IHostedService
{
    readonly ILogger logger;
    readonly IServiceProvider serviceProvider;
    readonly IHostApplicationLifetime lifetime;

    public Worker(
        ILogger<Worker> logger,        
        IServiceProvider serviceProvider,
        IHostApplicationLifetime lifetime
    )
    {
        this.logger = logger;        
        this.serviceProvider = serviceProvider;
        this.lifetime = lifetime;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var scope = serviceProvider.CreateScope();

        var sampleService = scope.ServiceProvider.GetRequiredService<ISampleService>();

        await sampleService.DoSomeJob(cancellationToken);      

        lifetime.StopApplication();  
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Stopping worker...");

        await Task.Delay(3000);

        logger.LogInformation("Worker gracefully stopped");
    }

}