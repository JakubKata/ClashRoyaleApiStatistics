using StatisticsAPI.Domain.Models;

namespace StatisticsAPI.Application.Rendering;

public interface IStatsRenderer
{
    string Render(PlayerStatistics stats);
}