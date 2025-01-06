namespace ExampleConsoleWorker;

public static partial class Extensions
{

    /// <summary>
    /// register application services
    /// </summary>
    public static void SetupServices(this IHostApplicationBuilder builder)
    {        
        builder.Services.AddSerilog(config =>
        {
            config.ReadFrom.Configuration(builder.Configuration);
        });        

        builder.Services.AddScoped<ISampleService, SampleService>();        

        builder.Services.AddHostedService<Worker>();        
    }

}