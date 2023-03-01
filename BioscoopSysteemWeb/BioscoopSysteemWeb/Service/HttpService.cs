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

    public async Task<string> GetDataFromApi()
    {
        var response = await _httpClient.GetAsync("http://www.omdbapi.com/?apikey=e3573bce&");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return string.Empty;
    }
}
