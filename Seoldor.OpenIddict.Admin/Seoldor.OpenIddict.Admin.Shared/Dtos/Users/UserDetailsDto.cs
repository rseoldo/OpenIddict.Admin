using Seoldor.OpenIddict.Admin.Shared.Dtos.Claims;

namespace Seoldor.OpenIddict.Admin.Shared.Dtos.Users;

public class UserDetailsDto
{
    public string Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public bool EmailConfirmed { get; set; }

    public List<string>? Roles { get; set; }
    public List<ClaimDto>? Claims { get; set; }
}
