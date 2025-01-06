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


### further logger configurations

further console args

```json
{
  "Serilog": {
    "Using": [
      "Serilog.Sinks.Console"
    ],
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
        //   "outputTemplate": "[{Level:u3}]({RequestId}) {Message:lj}{NewLine}{Exception}",
        //   "theme": "Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme::Literate, Serilog.Sinks.Console",
          // "applyThemeToRedirectedOutput": true          
          // "formatter": "Serilog.Formatting.Compact.CompactJsonFormatter, Serilog.Formatting.Compact"
        }
      }
    ],
    "Enrich": [
      "FromLogContext"
    ]
  }
}
```

### how this project was built

```sh
dn new console -n ExampleConsoleWorker
cd ExampleConsoleWorker
dotnet new gitignore
dotnet add package Microsoft.Extensions.Hosting --version 9.0.0
dotnet add package Serilog.Extensions.Hosting --version 9.0.0
dotnet add package Serilog.Settings.Configuration --version 9.0.0
dotnet add package Serilog.Sinks.Console --version 6.0.0
```

open with vscode the folder then `C-S-p` and type `.NET: Generate Assets for Build and Debug` to create `.vscode` launch and build json files