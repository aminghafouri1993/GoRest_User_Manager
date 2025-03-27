using GoRestUserManager.Models;
using System.Net.Http.Json;

namespace GoRestUserManager.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("GoRestClient");
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            var token = "Bearer 0ad7fb5a76d48ee68308fe869d6a7aa04f651df997aedb687eb4ee7293fa36b7";
            var request = new HttpRequestMessage(HttpMethod.Get, "users?per_page=10");
            request.Headers.Add("Authorization", token);

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return new List<UserViewModel>();

            var users = await response.Content.ReadFromJsonAsync<List<UserViewModel>>();
            return users?.OrderByDescending(u => u.Id).ToList() ?? new List<UserViewModel>();
        }
        public async Task<bool> CreateUserAsync(UserViewModel user)
        {
            var token = "Bearer 0ad7fb5a76d48ee68308fe869d6a7aa04f651df997aedb687eb4ee7293fa36b7";
            var request = new HttpRequestMessage(HttpMethod.Post, "users");
            request.Headers.Add("Authorization", token);
            request.Content = JsonContent.Create(user);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateUserAsync(UserViewModel user)
        {
            var token = "Bearer 0ad7fb5a76d48ee68308fe869d6a7aa04f651df997aedb687eb4ee7293fa36b7";
            var request = new HttpRequestMessage(HttpMethod.Put, $"users/{user.Id}");
            request.Headers.Add("Authorization", token);
            request.Content = JsonContent.Create(user);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var token = "Bearer 0ad7fb5a76d48ee68308fe869d6a7aa04f651df997aedb687eb4ee7293fa36b7";
            var request = new HttpRequestMessage(HttpMethod.Delete, $"users/{id}");
            request.Headers.Add("Authorization", token);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
