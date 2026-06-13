namespace StatisticsAPI.Application.Rendering;

public class StatsRendererFactory
{
    public IStatsRenderer CreateRenderer(string mode)
    {
        if (mode != null && mode.ToLower() == "detailed")
        {
            return new DetailedStatsRenderer();
        }

        return new BasicStatsRenderer();
    }
}