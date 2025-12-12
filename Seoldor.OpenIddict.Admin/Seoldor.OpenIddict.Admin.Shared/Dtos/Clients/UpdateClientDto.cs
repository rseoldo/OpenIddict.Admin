namespace Seoldor.OpenIddict.Admin.Shared.Dtos.Clients;

public class UpdateClientDto
{
    public string DisplayName { get; set; } = default!;
    public List<string> RedirectUris { get; set; } = new();
    public List<string> Permissions { get; set; } = new();
}

