using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Seoldor.OpenIddict.Admin.Infrastructure;
using Seoldor.OpenIddict.Admin.Shared.Dtos.Users;

namespace Seoldor.OpenIddict.Admin.Api;

//[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/admin/users")]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = _userManager.Users.ToList();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto dto)
    {
        var user = new ApplicationUser { FullName = dto.FullName, UserName = dto.UserName, Email = dto.Email };
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(user);
    }
}
