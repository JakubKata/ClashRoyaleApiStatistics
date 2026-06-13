namespace StatisticsAPI.Infrastructure;

public class ApiConfig
{
    public string BaseUrl { get; set; }
    public string Token { get; set; }

    public ApiConfig(string baseUrl, string token)
    {
        BaseUrl = baseUrl;
        Token = token;
    }

    public static ApiConfig FromEnvironment()
    {
        string token = Environment.GetEnvironmentVariable("CLASH_ROYALE_API_TOKEN");

        if (token == null || token.Trim().Length == 0)
        {
            throw new Exception("Missing token. Set the CLASH_ROYALE_API_TOKEN environment variable.");
        }

        return new ApiConfig("https://api.clashroyale.com/v1", token.Trim());
    }
}