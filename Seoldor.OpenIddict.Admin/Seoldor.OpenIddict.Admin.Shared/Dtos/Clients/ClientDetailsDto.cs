namespace Seoldor.OpenIddict.Admin.Shared.Dtos.Clients;

public class ClientDetailsDto
{
    public string Id { get; set; } = default!;
    public string ClientId { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
    public List<string> RedirectUris { get; set; } = new();
    public List<string> Permissions { get; set; } = new();
}
