using System.Text;
using StatisticsAPI.Domain.Models;

namespace StatisticsAPI.Application.Rendering;

public class BasicStatsRenderer : IStatsRenderer
{
    public string Render(PlayerStatistics stats)
    {
        StringBuilder text = new StringBuilder();

        text.AppendLine("=== Basic Statistics ===");
        text.AppendLine("Name: " + stats.Name);
        text.AppendLine("Tag: " + stats.Tag);
        text.AppendLine("Level: " + stats.ExpLevel);
        text.AppendLine("Trophies: " + stats.Trophies);
        text.AppendLine("Win rate: " + stats.WinRate.ToString("0.00") + "%");

        return text.ToString();
    }
}