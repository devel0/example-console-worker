var cts = new CancellationTokenSource();

InitializeDotnetEnvironment();

var builder = Host.CreateApplicationBuilder(args);

builder.SetupConfiguration();

// add basic services
builder.Services.AddScoped(typeof(CancellationToken), sp => cts.Token);
builder.Services.AddSerilog(config =>
{
    config.ReadFrom.Configuration(builder.Configuration);
});

// add custom services
builder.Services.AddScoped<ISampleService, SampleService>();

// setup console cancellation ( signal INT )
Console.CancelKeyPress += (a, b) => cts.Cancel();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

await host.RunAsync();
