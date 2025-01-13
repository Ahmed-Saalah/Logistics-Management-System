using LogisticsManagementSystem.DTO;
using LogisticsManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogisticsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IConfiguration Configure;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configure)
        {
            this.userManager = userManager;
            this.Configure = configure;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDTO userFromRequest)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userFromRequest.UserName,
                    Email = userFromRequest.Email,
                };

                var result = await userManager.CreateAsync(user, userFromRequest.Password);

                if (result.Succeeded)
                {
                    return Ok("User created successfully.");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
                return BadRequest(ModelState);
            }

            return BadRequest("Invalid data.");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginDTO userFromRequest)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = await userManager.FindByNameAsync(userFromRequest.UserName);

                if (userFromDb != null)
                {
                    bool found =
                        await userManager.CheckPasswordAsync(userFromDb, userFromRequest.Password);

                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDb.Id));
                        claims.Add(new Claim(ClaimTypes.Name, userFromDb.UserName));
                        // Token generated id change (JWT predefined claims)
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        var userRoles = await userManager.GetRolesAsync(userFromDb);
                        foreach (var roleName in userRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, roleName));
                        }

                        SymmetricSecurityKey signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configure["JWT:SecurityKey"]));

                        SigningCredentials signingCredential = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

                        // Design token
                        JwtSecurityToken Mytoken = new JwtSecurityToken(
                            issuer: Configure["JWT:IssuerIP"],
                            audience: Configure["JWT:AudienceIP"],
                            expires: DateTime.Now.AddHours(1),
                            claims: claims,
                            signingCredentials: signingCredential
                        );

                        // generate token
                        return Ok(
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(Mytoken),
                                expiration = DateTime.Now.AddHours(1) // Mytoken.ValidTo
                            });
                    }
                }

                ModelState.AddModelError("userName", "InValid username or password");
            }

            return BadRequest(ModelState);
        }
    }
}
