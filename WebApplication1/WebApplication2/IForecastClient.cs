namespace WebApplication2;

public interface IForecastClient
{
    Task<IEnumerable<WeatherForecast>> GetForecast();
}

public class ForecastClient : IForecastClient 
{
    private readonly HttpClient _client;

    public ForecastClient(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("http://web_server:80");
    }

    public async Task<IEnumerable<WeatherForecast>> GetForecast()
    {
        return await _client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast") ??
               Enumerable.Empty<WeatherForecast>();
    }
}

