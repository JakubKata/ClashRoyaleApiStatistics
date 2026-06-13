namespace StatisticsAPI.Domain.Models;

public class PlayerTag
{
    public string Value { get; set; }

    public PlayerTag(string text)
    {
        if (text == null)
        {
            throw new Exception("Player tag cannot be empty.");
        }

        text = text.Trim().ToUpper();

        if (text.Length == 0)
        {
            throw new Exception("Player tag cannot be empty.");
        }

        if (!text.StartsWith("#"))
        {
            text = "#" + text;
        }

        if (text.Length < 2)
        {
            throw new Exception("Player tag is too short.");
        }

        Value = text;
    }

    public string ToApiValue()
    {
        string withoutHash = Value.Substring(1);
        return "%23" + withoutHash;
    }
}