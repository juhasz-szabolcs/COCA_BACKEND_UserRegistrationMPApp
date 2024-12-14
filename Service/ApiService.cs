using System.Net.Http.Json;
using System.Text.Json;
using UserRegistrationMPApp;

public static class ApiService
{
    private static readonly string ApiBaseUrl = "https://yourapi.com/api";
    private static readonly HttpClient client = new HttpClient();
    private static readonly UserRepository userRepository = new UserRepository(); // Dummy adatokat tartalmazó repository

    public static async Task<bool> Login(string email, string password)
    {
        var response = await client.PostAsJsonAsync($"{ApiBaseUrl}/login", new { email, password });
        return response.IsSuccessStatusCode;
    }

    public static async Task<bool> Register(User user)
    {
        var response = await client.PostAsJsonAsync($"{ApiBaseUrl}/register", user);
        return response.IsSuccessStatusCode;
    }

    //public static async Task<User> GetUserProfile(string email)
    //{
    //    var response = await client.GetAsync($"{ApiBaseUrl}/profile?email={email}");
    //    if (response.IsSuccessStatusCode)
    //    {
    //        return await response.Content.ReadFromJsonAsync<User>();
    //    }
    //    return null;
    //}

    public static async Task<User?> GetUserProfile(string email)
    {
        // Helyettesítsd az API hívást a repository-ból való lekérdezéssel
        var user = await userRepository.GetUserByEmailAsync(email);
        return user;
    }

    public static async Task<bool> UpdateProfile(User user)
    {
        var response = await client.PutAsJsonAsync($"{ApiBaseUrl}/profile", user);
        return response.IsSuccessStatusCode;
    }
}
