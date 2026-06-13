using System.Text.Json;

namespace StatisticsAPI.Infrastructure;

public class ApiConfig
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public static ApiConfig FromJsonFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        ApiConfig? config = JsonSerializer.Deserialize<ApiConfigWrapper>(json, options)?.ClashRoyaleApi;
        return config ?? new ApiConfig();
    }

    private sealed class ApiConfigWrapper
    {
        public ApiConfig? ClashRoyaleApi { get; set; }
    }
}