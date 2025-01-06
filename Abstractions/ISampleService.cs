namespace ExampleConsoleWorker;

public interface ISampleService
{

    Task DoSomeJob(CancellationToken cancellationToken);

}