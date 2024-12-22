namespace MyArchive.Web;

public class WebApiClient
{
    private readonly HttpClient _httpClient;

    public WebApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetImageDataAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var imageBytes = await response.Content.ReadAsByteArrayAsync();
            var imageData = Convert.ToBase64String(imageBytes);
            return imageData;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            return null;
        }
    }
}

