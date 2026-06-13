using System.Text;
using StatisticsAPI.Domain.Models;

namespace StatisticsAPI.Application.Rendering;

public class DetailedStatsRenderer : IStatsRenderer
{
    public string Render(PlayerStatistics stats)
    {
        StringBuilder text = new StringBuilder();

        text.AppendLine("=== Detailed Statistics ===");
        text.AppendLine("Name: " + stats.Name);
        text.AppendLine("Tag: " + stats.Tag);
        text.AppendLine("Level: " + stats.ExpLevel);
        text.AppendLine("Trophies: " + stats.Trophies);
        text.AppendLine("Best trophy result: " + stats.BestTrophies);
        text.AppendLine("Clan: " + stats.ClanName);
        text.AppendLine("Arena: " + stats.ArenaName);
        text.AppendLine("Wins: " + stats.Wins);
        text.AppendLine("Losses: " + stats.Losses);
        text.AppendLine("Battle count: " + stats.BattleCount);
        text.AppendLine("Win rate: " + stats.WinRate.ToString("0.00") + "%");
        text.AppendLine("Last battle: " + stats.LastBattleResult);
        text.AppendLine("Upcoming chests: " + stats.NextChests);

        return text.ToString();
    }
}