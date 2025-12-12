using Seoldor.OpenIddict.Admin.Shared.Dtos.Users;
namespace Seoldor.OpenIddict.Admin.UI.Services;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(string id);
    Task<UserDetailsDto?> GetDetailsAsync(string id);
    Task<bool> CreateAsync(CreateUserDto dto);
    Task<bool> UpdateAsync(string id, UpdateUserDto dto);
    Task<bool> DeleteAsync(string id);
}
