using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;
using Seoldor.OpenIddict.Admin.Shared.Dtos.Clients;

namespace Seoldor.OpenIddict.Admin.Api.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/admin/clients")]
public class ClientsController : ControllerBase
{
    private readonly OpenIddictApplicationManager<OpenIddictEntityFrameworkCoreApplication> _manager;

    public ClientsController(OpenIddictApplicationManager<OpenIddictEntityFrameworkCoreApplication> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        var clients = await _manager.ListAsync().ToListAsync();
        return Ok(clients);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientDto dto)
    {
        var client = new OpenIddictEntityFrameworkCoreApplication
        {
            ClientId = dto.ClientId,
            DisplayName = dto.DisplayName
        };
        await _manager.CreateAsync(client, dto.ClientSecret);
        return Ok(client);
    }
}
