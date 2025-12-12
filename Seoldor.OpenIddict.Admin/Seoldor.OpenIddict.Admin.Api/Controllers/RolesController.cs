using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Seoldor.OpenIddict.Admin.Shared.Dtos.Roles;

namespace Seoldor.OpenIddict.Admin.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin/roles")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetRoles() => Ok(_roleManager.Roles.ToList());

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(dto.Name));
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(dto);
        }
    }
}
