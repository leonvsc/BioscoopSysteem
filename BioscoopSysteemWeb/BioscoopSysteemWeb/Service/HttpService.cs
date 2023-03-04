namespace BioscoopSysteemWeb.Service;
using System.Net.Http;
using System.Threading.Tasks;

public class HttpService
{
    private readonly HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetMovies()
    {
        var response = await _httpClient.GetAsync("https://localhost:44307/api/movie");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return string.Empty;
    }
    
    public async Task<string> GetMovieById(int id)
    {
        var response = await _httpClient.GetAsync($"https://localhost:44307/api/movie/{id}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return string.Empty;
    }
}
