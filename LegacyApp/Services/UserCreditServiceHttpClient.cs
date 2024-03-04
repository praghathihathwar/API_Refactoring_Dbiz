namespace LegacyApp.Services;

public class UserCreditServiceHttpClient : IUserCreditServiceHttpClient
{
    private readonly HttpClient _httpClient;
    public UserCreditServiceHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<int> GetCreditLimitAsync(string firstName, string surname, DateTime dateOfBirth)
    {
        var baseUrl = "http://eqfx-real-service.com";
        var endpoint = "/IUserCreditService/GetCreditLimit";

        // Construct the request URL
        var requestUrl = $"{baseUrl}{endpoint}?firstname={firstName}&surname={surname}&dateOfBirth={dateOfBirth}";

        try
        {
            // Make the HTTP request using HttpClient
            var response = await _httpClient.GetAsync(requestUrl);

            // Check if the request was successful
            response.EnsureSuccessStatusCode();

            // Parse and return the response content as an integer
            int creditLimit = int.Parse(await response.Content.ReadAsStringAsync());
            return creditLimit;
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions or log errors
            Console.WriteLine($"Error accessing user credit service: {ex.Message}");
            throw; 
        }
    }
}
