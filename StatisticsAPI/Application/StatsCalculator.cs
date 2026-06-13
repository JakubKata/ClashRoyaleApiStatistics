using System.Text;
using StatisticsAPI.Domain.Models;

namespace StatisticsAPI.Application;

public class StatsCalculator
{
    public PlayerStatistics Calculate(PlayerProfileDto profile, List<BattleLogItemDto> battleLog, ChestListDto chests)
    {
        PlayerStatistics stats = new PlayerStatistics();

        stats.Name = profile.Name;
        stats.Tag = profile.Tag;
        stats.ExpLevel = profile.ExpLevel;
        stats.Trophies = profile.Trophies;
        stats.BestTrophies = profile.BestTrophies;
        stats.Wins = profile.Wins;
        stats.Losses = profile.Losses;
        stats.BattleCount = profile.BattleCount;
        stats.WinRate = CalculateWinRate(profile.Wins, profile.Losses);
        stats.ClanName = GetClanName(profile);
        stats.ArenaName = GetArenaName(profile);
        stats.LastBattleResult = GetLastBattleResult(battleLog, profile.Tag);
        stats.NextChests = BuildNextChests(chests);

        return stats;
    }

    public double CalculateWinRate(int wins, int losses)
    {
        int all = wins + losses;

        if (all == 0)
        {
            return 0;
        }

        return wins * 100.0 / all;
    }

    private string GetClanName(PlayerProfileDto profile)
    {
        if (profile.Clan == null)
        {
            return "No clan";
        }

        if (profile.Clan.Name == null || profile.Clan.Name.Length == 0)
        {
            return "No clan";
        }

        return profile.Clan.Name;
    }

    private string GetArenaName(PlayerProfileDto profile)
    {
        if (profile.Arena == null)
        {
            return "No arena";
        }

        if (profile.Arena.Name == null || profile.Arena.Name.Length == 0)
        {
            return "No arena";
        }

        return profile.Arena.Name;
    }

    private string BuildNextChests(ChestListDto chests)
    {
        if (chests == null || chests.Items == null || chests.Items.Count == 0)
        {
            return "No data";
        }

        int limit = 5;

        if (chests.Items.Count < limit)
        {
            limit = chests.Items.Count;
        }

        StringBuilder text = new StringBuilder();

        for (int i = 0; i < limit; i++)
        {
            ChestDto chest = chests.Items[i];
            text.Append(chest.Index);
            text.Append(": ");
            text.Append(chest.Name);

            if (i < limit - 1)
            {
                text.Append(", ");
            }
        }

        return text.ToString();
    }

    private string GetLastBattleResult(List<BattleLogItemDto> battleLog, string playerTag)
    {
        if (battleLog == null || battleLog.Count == 0)
        {
            return "No data";
        }

        BattleLogItemDto battle = battleLog[0];

        BattlePlayerDto playerInTeam = FindPlayer(battle.Team, playerTag);
        BattlePlayerDto playerInOpponent = FindPlayer(battle.Opponent, playerTag);

        int playerCrowns = 0;
        int enemyCrowns = 0;

        if (playerInTeam != null)
        {
            playerCrowns = GetCrowns(battle.Team);
            enemyCrowns = GetCrowns(battle.Opponent);
        }
        else if (playerInOpponent != null)
        {
            playerCrowns = GetCrowns(battle.Opponent);
            enemyCrowns = GetCrowns(battle.Team);
        }
        else
        {
            return "No data";
        }

        if (playerCrowns > enemyCrowns)
        {
            return "Win " + playerCrowns + ":" + enemyCrowns;
        }

        if (playerCrowns < enemyCrowns)
        {
            return "Loss " + playerCrowns + ":" + enemyCrowns;
        }

        return "Draw " + playerCrowns + ":" + enemyCrowns;
    }

    private BattlePlayerDto FindPlayer(List<BattlePlayerDto> players, string playerTag)
    {
        if (players == null)
        {
            return null;
        }

        string correctTag = playerTag.ToUpper();

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].Tag != null && players[i].Tag.ToUpper() == correctTag)
            {
                return players[i];
            }
        }

        return null;
    }

    private int GetCrowns(List<BattlePlayerDto> players)
    {
        if (players == null || players.Count == 0)
        {
            return 0;
        }

        return players[0].Crowns;
    }
}