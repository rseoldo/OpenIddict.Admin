using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Seoldor.OpenIddict.Admin.Infrastructure;
using System.Security.Claims;

namespace Seoldor.OpenIddict.Admin.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin/claims")]
    public class ClaimsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserClaims(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var claims = await _userManager.GetClaimsAsync(user);
            return Ok(claims);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddClaim(string userId, [FromBody] Claim claim)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var result = await _userManager.AddClaimAsync(user, claim);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(claim);
        }
    }
}
