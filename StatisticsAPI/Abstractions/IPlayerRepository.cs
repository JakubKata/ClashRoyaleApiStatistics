using StatisticsAPI.Domain.Models;

namespace StatisticsAPI.Abstractions;

public interface IPlayerRepository
{
    Task<PlayerProfileDto> GetProfileAsync(PlayerTag playerTag, CancellationToken cancellationToken);
    Task<List<BattleLogItemDto>> GetBattleLogAsync(PlayerTag playerTag, CancellationToken cancellationToken);
    Task<ChestListDto> GetUpcomingChestsAsync(PlayerTag playerTag, CancellationToken cancellationToken);
}