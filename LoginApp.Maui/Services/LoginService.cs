using LoginApp.Maui.Models;
using System.Net.Http.Json;

namespace LoginApp.Maui.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var client = new HttpClient();
                string localhostUrl = $"https://localhost:7138/api/users/Login/{email}/{password}";
                client.BaseAddress = new Uri(localhostUrl);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    User? user = await response.Content.ReadFromJsonAsync<User>() ?? new();
                    return await Task.FromResult(user);
                }

                return new();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return new();
            }
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
