using StatisticsAPI.Abstractions;
using StatisticsAPI.Application.Rendering;
using StatisticsAPI.Domain.Models;
using StatisticsAPI.Infrastructure;

namespace StatisticsAPI.Application;

public class ConsoleApp
{
    private IConsole console;
    private IPlayerRepository repository;
    private StatsCalculator calculator;
    private StatsRendererFactory rendererFactory;

    public ConsoleApp(IConsole console, IPlayerRepository repository, StatsCalculator calculator, StatsRendererFactory rendererFactory)
    {
        this.console = console;
        this.repository = repository;
        this.calculator = calculator;
        this.rendererFactory = rendererFactory;
    }

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        try
        {
            console.WriteLine("=== Clash Royale Player Stats ===");

            PlayerTag playerTag = ReadPlayerTag();
            string mode = ReadMode();

            console.WriteLine("");
            console.WriteLine("Fetching data from the API...");

            PlayerProfileDto profile = await repository.GetProfileAsync(playerTag, cancellationToken);
            List<BattleLogItemDto> battleLog = await repository.GetBattleLogAsync(playerTag, cancellationToken);
            ChestListDto chests = await repository.GetUpcomingChestsAsync(playerTag, cancellationToken);

            PlayerStatistics stats = calculator.Calculate(profile, battleLog, chests);
            IStatsRenderer renderer = rendererFactory.CreateRenderer(mode);

            console.WriteLine("");
            console.WriteLine(renderer.Render(stats));
        }
        catch (ApiException ex)
        {
            console.WriteLine("API error. Code: " + ex.StatusCode);
            console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            console.WriteLine("Error: " + ex.Message);
        }
    }

    private PlayerTag ReadPlayerTag()
    {
        console.Write("Enter the player tag, e.g. #ABC123: ");
        string text = console.ReadLine();
        return new PlayerTag(text);
    }

    private string ReadMode()
    {
        console.Write("Enter mode: basic or detailed: ");
        string mode = console.ReadLine();

        if (mode == null)
        {
            return "basic";
        }

        mode = mode.Trim().ToLower();

        if (mode == "detailed")
        {
            return "detailed";
        }

        return "basic";
    }
}