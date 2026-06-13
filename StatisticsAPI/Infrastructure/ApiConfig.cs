using System.Text.Json;

namespace StatisticsAPI.Infrastructure;

public class ApiConfig
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public static ApiConfig FromJsonFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Nie znaleziono pliku konfiguracyjnego: {filePath}");
        }

        string json = File.ReadAllText(filePath);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        ApiConfig? config = JsonSerializer.Deserialize<ApiConfigWrapper>(json, options)?.ClashRoyaleApi;

        if (string.IsNullOrEmpty(config?.Token))
        {
            throw new Exception("API token is missing in the configuration file.");
        }

        return config;
    }

    private sealed class ApiConfigWrapper
    {
        public ApiConfig? ClashRoyaleApi { get; set; }
    }
}