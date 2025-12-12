using Microsoft.AspNetCore.Identity;

namespace Seoldor.OpenIddict.Admin.Infrastructure;

public class ApplicationUser : IdentityUser
{
    // Você pode adicionar campos extras aqui, ex: FullName, BirthDate
    public string FullName { get; set; }
}
