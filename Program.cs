InitializeDotnetEnvironment();

var builder = Host.CreateApplicationBuilder(args);

builder.SetupConfiguration();

builder.SetupServices();

var host = builder.Build();

await host.RunAsync();
