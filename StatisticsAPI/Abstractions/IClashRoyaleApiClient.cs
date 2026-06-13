namespace StatisticsAPI.Abstractions;

public interface IClashRoyaleApiClient
{
    Task<string> GetJsonAsync(string relativePath, CancellationToken cancellationToken);
}