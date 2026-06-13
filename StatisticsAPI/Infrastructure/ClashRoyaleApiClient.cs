using System.Net.Http;
using StatisticsAPI.Abstractions;

namespace StatisticsAPI.Infrastructure;

public class ClashRoyaleApiClient : IClashRoyaleApiClient
{
    private ApiConfig config;
    private HttpClient httpClient;

    public ClashRoyaleApiClient(ApiConfig config, HttpClient httpClient)
    {
        this.config = config;
        this.httpClient = httpClient;
    }

    public async Task<string> GetJsonAsync(string relativePath, CancellationToken cancellationToken)
    {
        string url = config.BaseUrl + relativePath;

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", "Bearer " + config.Token);

        HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken);
        string json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            int code = (int)response.StatusCode;
            throw new ApiException(code, "The server returned an error. Response: " + json);
        }

        return json;
    }
}