# Example console hosted worker

- [features](#features)
- [quickstart](#quickstart)
- [dev notes](#dev-notes)
  - [code map](#code-map)
  - [further logger configurations](#further-logger-configurations)
  - [how this project was built](#how-this-project-was-built)

## features

- hosted application with scoped services
- application configuration through appsettings, environment var and user secrets
- appsettings AppConfig object typed configuration
- serilog logger
- handle application graceful shutdown, allow service to invoke app shutdown through lifetime

## quickstart

- install repo as template

```sh
git clone https://github.com/devel0/example-console-worker.git
cd example-console-worker
dotnet new install .
cd ..
```

- create project from template

```sh
dotnet new example-console-worker -n project-folder --namespace My.Some
cd project-folder
dotnet build
```

## dev notes

### code map

| link | description                              |
| ---- | ---------------------------------------- |
| [1]  | register services                        |
| [2]  | require scoped service from worker scope |
| [3]  | invoke app shutdown programmatically     |
| [4]  | inject scoped services                   |
| [6]  | typed appconfig read from [json][5]      |
| [7]  | sample service interface                 |
| [8]  | sample service implmentation             |

[1]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/Extensions/SetupServices.cs#L11
[2]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/Implementations/Worker.cs#L25
[3]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/Implementations/Worker.cs
[4]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/Implementations/SampleService.cs
[5]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/appsettings.json
[6]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/Abstractions/AppConfig.cs
[7]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/Abstractions/ISampleService.cs
[8]: https://github.com/devel0/example-console-worker/blob/b6f63f8396352bdac1743b6a6b5032913232aec2/Implementations/SampleService.cs

### further logger configurations

further console args

```json
{
  "Serilog": {    
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "outputTemplate": "[{Level:u3}]({RequestId}) {Message:lj}{NewLine}{Exception}",          
          "formatter": "Serilog.Formatting.Compact.CompactJsonFormatter, Serilog.Formatting.Compact"
        }
      }
    ]    
  }
}
```

### how this project was built

```sh
dotnet new console -n ExampleConsoleWorker
cd ExampleConsoleWorker
dotnet new gitignore
dotnet add package Microsoft.Extensions.Hosting --version 9.0.0
dotnet add package Serilog.Extensions.Hosting --version 9.0.0
dotnet add package Serilog.Settings.Configuration --version 9.0.0
dotnet add package Serilog.Sinks.Console --version 6.0.0
```

open with vscode the folder then `C-S-p` and type `.NET: Generate Assets for Build and Debug` to create `.vscode` launch and build json files