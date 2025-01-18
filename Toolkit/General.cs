namespace ExampleConsoleWorker;

public static partial class Toolkit
{

    /// <summary>
    /// if compile DEBUG symbol defined setup DOTNET_ENVIRONMENT variabile to Development if not already set
    /// </summary>
    public static void InitializeDotnetEnvironment()
    {
        var debugAttr = Assembly.GetExecutingAssembly().GetCustomAttribute<DebuggableAttribute>();

        if (
            debugAttr is not null
            &&
            ((debugAttr.DebuggingFlags & DebuggableAttribute.DebuggingModes.Default) == DebuggableAttribute.DebuggingModes.Default)
            )
        {
            if (Environment.GetEnvironmentVariable(Environment_DOTNET_ENVIRONMENT) is null)
                Environment.SetEnvironmentVariable(Environment_DOTNET_ENVIRONMENT, EnvironmentName_Development);
        }
    }

}
