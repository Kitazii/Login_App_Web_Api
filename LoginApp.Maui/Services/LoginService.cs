using LoginApp.Maui.Models;
using System.Net.Http.Json;

namespace LoginApp.Maui.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<User?> Login(string email, string password)
        {
            try
            {
                var client = new HttpClient();
                string localhostUrl = $"http://10.0.2.2:5189/api/users/Login/{email}/{password}"; //http for andriod
                client.BaseAddress = new Uri(localhostUrl);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    User? user = await response.Content.ReadFromJsonAsync<User>() ?? null;
                    return await Task.FromResult(user);
                }

                return null;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
