namespace StatisticsAPI.Domain.Models;

public class PlayerStatistics
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public int ExpLevel { get; set; }
    public int Trophies { get; set; }
    public int BestTrophies { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int BattleCount { get; set; }
    public double WinRate { get; set; }
    public string ClanName { get; set; }
    public string ArenaName { get; set; }
    public string LastBattleResult { get; set; }
    public string NextChests { get; set; }

    public PlayerStatistics()
    {
        Name = "";
        Tag = "";
        ClanName = "";
        ArenaName = "";
        LastBattleResult = "";
        NextChests = "";
    }
}