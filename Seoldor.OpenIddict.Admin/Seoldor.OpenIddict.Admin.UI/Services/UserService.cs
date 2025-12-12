using Seoldor.OpenIddict.Admin.Shared.Dtos.Users;

namespace Seoldor.OpenIddict.Admin.UI.Services;

public class UserService : IUserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }

    public Task<List<UserDto>> GetAllAsync()
        => _http.GetFromJsonAsync<List<UserDto>>("api/admin/users");

    public Task<UserDto?> GetByIdAsync(string id)
        => _http.GetFromJsonAsync<UserDto>($"api/users/{id}");

    public Task<UserDetailsDto?> GetDetailsAsync(string id)
    => _http.GetFromJsonAsync<UserDetailsDto>($"api/users/{id}/details");

    public Task<bool> CreateAsync(CreateUserDto dto)
        => PostAsync("api/admin/users", dto);

    public Task<bool> UpdateAsync(string id, UpdateUserDto dto)
        => PutAsync($"api/users/{id}", dto);

    public Task<bool> DeleteAsync(string id)
        => DeleteRequestAsync($"api/users/{id}");


    private async Task<bool> PostAsync(string url, object data)
    {
        var response = await _http.PostAsJsonAsync(url, data);
        return response.IsSuccessStatusCode;
    }

    private async Task<bool> PutAsync(string url, object data)
    {
        var response = await _http.PutAsJsonAsync(url, data);
        return response.IsSuccessStatusCode;
    }

    private async Task<bool> DeleteRequestAsync(string url)
    {
        var response = await _http.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}
