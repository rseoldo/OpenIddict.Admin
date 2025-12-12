using System.ComponentModel.DataAnnotations;

namespace Seoldor.OpenIddict.Admin.Shared.Dtos.Users;

public class UpdateUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string UserName { get; set; } = default!;

    public bool EmailConfirmed { get; set; }
}
