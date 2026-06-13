using StatisticsAPI.Abstractions;
using StatisticsAPI.Application;
using StatisticsAPI.Application.Rendering;
using StatisticsAPI.Infrastructure;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            ApiConfig config = ApiConfig.FromEnvironment();
            HttpClient httpClient = new HttpClient();

            IClashRoyaleApiClient apiClient = new ClashRoyaleApiClient(config, httpClient);
            JsonParser parser = new JsonParser();
            IPlayerRepository repository = new ClashRoyalePlayerRepository(apiClient, parser);

            IConsole console = new ConsoleAdapter();
            StatsCalculator calculator = new StatsCalculator();
            StatsRendererFactory rendererFactory = new StatsRendererFactory();

            ConsoleApp app = new ConsoleApp(console, repository, calculator, rendererFactory);
            await app.RunAsync(CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Program error: " + ex.Message);
        }
    }
}
