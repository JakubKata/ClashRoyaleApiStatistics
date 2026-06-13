# StatisticsAPI

StatisticsAPI is a small .NET console application that fetches and computes player statistics from the Clash Royale API. The project follows a layered structure with `Domain`, `Abstractions`, `Application`, and `Infrastructure` layers, and includes simple console rendering components.

Supported scenarios:

- Fetch player data from the external Clash Royale API
- Compute and format basic and detailed statistics
- Render results in basic and detailed modes
- API error handling via `ApiException`
- Configuration of the API client via `appsettings.json`

---

## Features

- Layered architecture (`Domain`, `Abstractions`, `Application`, `Infrastructure`)
- HTTP client for Clash Royale (`ClashRoyaleApiClient`) and repository (`ClashRoyalePlayerRepository`)
- Statistics calculation module (`StatsCalculator`)
- Multiple statistics renderers and a renderer factory (`Application/Rendering`)
- Console adapter and `IConsole` abstraction to isolate UI logic

---

## Requirements

- .NET 10 SDK (target: `net10.0`)
- Internet access (to call the Clash Royale API)

The `appsettings.json` file is copied to the output directory and contains API connection configuration (example below).

---

## Configuration (`appsettings.json`)

Put a `ClashRoyaleApi` section in `appsettings.json` with these values:

```json
{
  "ClashRoyaleApi": {
    "BaseUrl": "https://api.clashroyale.com/v1/",
    "Token": "YOUR_API_TOKEN"
  }
}
```

The `ApiConfig` class reads `ClashRoyaleApi.BaseUrl` and `ClashRoyaleApi.Token` from the JSON file.

---

## Quick Start (Windows / Linux)

1. Install .NET 10 SDK: https://dotnet.microsoft.com

2. Build the project:

```bash
dotnet build
```

3. Run the application from the repository root:

```bash
dotnet run --project StatisticsAPI/StatisticsAPI.csproj
```

---

## Running and debugging

- The application is a console app; `Program.cs` configures DI and starts `ConsoleApp`.
- Make sure the `Token` in `appsettings.json` is set to a valid API token.

---

## Recommendations

- Add a test project (e.g. `StatisticsAPI.Tests`) and unit tests for `StatsCalculator` and `ClashRoyalePlayerRepository`.
- Add CI (build + test) to the repository.
- Do not store secrets (API tokens) in source; use environment variables or `dotnet user-secrets` during development.
- Consider renaming `StatisticsAPI.slnx` to `StatisticsAPI.sln` if your tools expect the standard `.sln` extension.

---

## Project structure (shortened)

```
StatisticsAPI/
├── StatisticsAPI/
│   ├── Program.cs
│   ├── appsettings.json
│   ├── Abstractions/
│   │   ├── IClashRoyaleApiClient.cs
│   │   ├── IConsole.cs
│   │   └── IPlayerRepository.cs
│   ├── Application/
│   │   ├── ConsoleApp.cs
│   │   ├── StatsCalculator.cs
│   │   └── Rendering/
│   │       ├── BasicStatsRenderer.cs
│   │       ├── DetailedStatsRenderer.cs
│   │       ├── IStatsRenderer.cs
│   │       └── StatsRendererFactory.cs
│   ├── Domain/
│   │   └── Models/
│   │       ├── ClashRoyaleDtos.cs
│   │       ├── PlayerStatistics.cs
│   │       └── PlayerTag.cs
│   └── Infrastructure/
│       ├── ApiConfig.cs
│       ├── ApiException.cs
│       ├── ClashRoyaleApiClient.cs
│       ├── ClashRoyalePlayerRepository.cs
│       ├── ConsoleAdapter.cs
│       └── JsonParser.cs
├── .gitignore
└── StatisticsAPI.slnx
```

---

## License

MIT