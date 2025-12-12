using Seoldor.OpenIddict.Admin.Shared.Dtos.Roles;
using Seoldor.OpenIddict.Admin.Shared.Dtos.Users;

namespace Seoldor.OpenIddict.Admin.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        // Usuários
        public async Task<List<UserDto>> GetUsersAsync() =>
            await _http.GetFromJsonAsync<List<UserDto>>("api/admin/users");

        public async Task CreateUserAsync(CreateUserDto dto) =>
            await _http.PostAsJsonAsync("api/admin/users", dto);

        // Roles
        public async Task<List<RoleDto>> GetRolesAsync() =>
            await _http.GetFromJsonAsync<List<RoleDto>>("api/admin/roles");

        public async Task CreateRoleAsync(CreateRoleDto dto) =>
            await _http.PostAsJsonAsync("api/admin/roles", dto);
    }
}
