namespace StatisticsAPI.Domain.Models;

public class PlayerProfileDto
{
    public string Tag { get; set; }
    public string Name { get; set; }
    public int ExpLevel { get; set; }
    public int Trophies { get; set; }
    public int BestTrophies { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int BattleCount { get; set; }
    public ClanDto Clan { get; set; }
    public ArenaDto Arena { get; set; }

    public PlayerProfileDto()
    {
        Tag = "";
        Name = "";
        Clan = new ClanDto();
        Arena = new ArenaDto();
    }
}

public class ClanDto
{
    public string Tag { get; set; }
    public string Name { get; set; }

    public ClanDto()
    {
        Tag = "";
        Name = "";
    }
}

public class ArenaDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ArenaDto()
    {
        Name = "";
    }
}

public class BattleLogItemDto
{
    public string Type { get; set; }
    public string BattleTime { get; set; }
    public List<BattlePlayerDto> Team { get; set; }
    public List<BattlePlayerDto> Opponent { get; set; }

    public BattleLogItemDto()
    {
        Type = "";
        BattleTime = "";
        Team = new List<BattlePlayerDto>();
        Opponent = new List<BattlePlayerDto>();
    }
}

public class BattlePlayerDto
{
    public string Tag { get; set; }
    public string Name { get; set; }
    public int Crowns { get; set; }
    public int KingTowerHitPoints { get; set; }
    public List<CardDto> Cards { get; set; }

    public BattlePlayerDto()
    {
        Tag = "";
        Name = "";
        Cards = new List<CardDto>();
    }
}

public class CardDto
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int MaxLevel { get; set; }

    public CardDto()
    {
        Name = "";
    }
}

public class ChestListDto
{
    public List<ChestDto> Items { get; set; }

    public ChestListDto()
    {
        Items = new List<ChestDto>();
    }
}

public class ChestDto
{
    public int Index { get; set; }
    public string Name { get; set; }

    public ChestDto()
    {
        Name = "";
    }
}