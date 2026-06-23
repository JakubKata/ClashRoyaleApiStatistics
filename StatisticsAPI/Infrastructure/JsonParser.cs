using System.Text.Json;
using StatisticsAPI.Domain.Models;

namespace StatisticsAPI.Infrastructure;

public class JsonParser
{
    private readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public PlayerProfileDto ParseProfile(string json)
    {
        PlayerProfileDto profile = JsonSerializer.Deserialize<PlayerProfileDto>(json, options);

        if (profile == null)
        {
            throw new Exception("Unable to read the player profile.");
        }

        return profile;
    }

    public List<BattleLogItemDto> ParseBattleLog(string json)
    {
        List<BattleLogItemDto> battleLog = JsonSerializer.Deserialize<List<BattleLogItemDto>>(json, options);

        if (battleLog == null)
        {
            return new List<BattleLogItemDto>();
        }

        return battleLog;
    }

    public ChestListDto ParseChests(string json)
    {
        ChestListDto chests = JsonSerializer.Deserialize<ChestListDto>(json, options);

        if (chests == null)
        {
            return new ChestListDto();
        }

        if (chests.Items == null)
        {
            chests.Items = new List<ChestDto>();
        }

        return chests;
    }
}