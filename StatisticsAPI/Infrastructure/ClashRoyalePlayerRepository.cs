using StatisticsAPI.Abstractions;
using StatisticsAPI.Domain.Models;

namespace StatisticsAPI.Infrastructure;

public class ClashRoyalePlayerRepository : IPlayerRepository
{
    private IClashRoyaleApiClient apiClient;
    private JsonParser jsonParser;

    public ClashRoyalePlayerRepository(IClashRoyaleApiClient apiClient, JsonParser jsonParser)
    {
        this.apiClient = apiClient;
        this.jsonParser = jsonParser;
    }

    public async Task<PlayerProfileDto> GetProfileAsync(PlayerTag playerTag, CancellationToken cancellationToken)
    {
        string path = "/players/" + playerTag.ToApiValue();
        string json = await apiClient.GetJsonAsync(path, cancellationToken);
        return jsonParser.ParseProfile(json);
    }

    public async Task<List<BattleLogItemDto>> GetBattleLogAsync(PlayerTag playerTag, CancellationToken cancellationToken)
    {
        string path = "/players/" + playerTag.ToApiValue() + "/battlelog";
        string json = await apiClient.GetJsonAsync(path, cancellationToken);
        return jsonParser.ParseBattleLog(json);
    }

    public async Task<ChestListDto> GetUpcomingChestsAsync(PlayerTag playerTag, CancellationToken cancellationToken)
    {
        string path = "/players/" + playerTag.ToApiValue() + "/upcomingchests";
        string json = await apiClient.GetJsonAsync(path, cancellationToken);
        return jsonParser.ParseChests(json);
    }
}