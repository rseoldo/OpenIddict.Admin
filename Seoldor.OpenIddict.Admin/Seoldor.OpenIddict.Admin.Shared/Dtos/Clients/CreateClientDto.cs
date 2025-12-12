namespace Seoldor.OpenIddict.Admin.Shared.Dtos.Clients;

public class CreateClientDto
{
    public string ClientId { get; set; } = default!;
    public string ClientSecret { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
    public List<string> RedirectUris { get; set; } = new();
    public List<string> Permissions { get; set; } = new();
}


