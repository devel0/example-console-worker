
namespace ExampleConsoleWorker;

public class SampleService : ISampleService
{
    readonly ILogger logger;
    readonly IHostEnvironment environment;
    readonly IConfiguration configuration;

    public SampleService(
        ILogger<SampleService> logger,
        IHostEnvironment environment,
        IConfiguration configuration
    )
    {
        this.logger = logger;
        this.environment = environment;
        this.configuration = configuration;
    }

    public async Task DoSomeJob(CancellationToken cancellationToken)
    {
        logger.LogDebug($"doing some work with sample service");

        var appConfig = configuration.GetSection(AppSettings_AppConfig).Get<AppConfig>();
        if (appConfig?.SampleObject?.SampleVar is not null)
            logger.LogDebug($"{nameof(AppConfig)} -> {nameof(AppConfig.SampleObject)} -> {nameof(AppConfig.SampleObject.SampleVar)} : {appConfig.SampleObject.SampleVar}");

        logger.LogInformation("Fake await 30 sec");

        try
        {
            await Task.Delay(30000, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Service received cancel during execution");
        }

        logger.LogDebug($"sample service finished");
    }

}