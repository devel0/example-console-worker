namespace ExampleConsoleWorker;

public static partial class Toolkit
{

    /// <summary>
    /// if compile DEBUG symbol defined setup DOTNET_ENVIRONMENT variabile to Development if not already set
    /// </summary>
    public static void InitializeDotnetEnvironment()
    {
#if DEBUG
        if (Environment.GetEnvironmentVariable(Environment_DOTNET_ENVIRONMENT) is null)
            Environment.SetEnvironmentVariable(Environment_DOTNET_ENVIRONMENT, EnvironmentName_Development);
#endif
    }

}
