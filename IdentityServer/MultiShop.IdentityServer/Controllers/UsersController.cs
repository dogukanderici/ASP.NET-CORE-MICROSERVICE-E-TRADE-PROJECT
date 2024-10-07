using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using MultiShop.IdentityServer.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            // Jwt token'daki sub değerine erişim sağlar.
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            var user = await _userManager.FindByIdAsync(userClaim.Value);

            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Username = user.UserName,
            });
        }

        [HttpGet("GetUserDefault")]
        public async Task<IActionResult> GetUserDefault()
        {
            // Jwt token'daki sub değerine erişim sağlar.
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            var user = await _userManager.FindByIdAsync(userClaim.Value);

            return Ok(user);
        }

        [HttpGet("ChangePassword/{newPassword}")]
        public async Task<IActionResult> ChangePassword(string newPassword)
        {
            // Jwt token'daki sub değerine erişim sağlar.
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, newPassword);

            var changePasswordResult = await _userManager.UpdateAsync(user);

            return Ok(changePasswordResult.Succeeded ? true : false);
        }

        [HttpPost("ChangePersonalInfo")]
        public async Task<IActionResult> ChangePersonalInfo(PersonalInfoViewModel changePersonalInfoViewModel)
        {
            // Jwt token'daki sub değerine erişim sağlar.
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);

            user.Name = changePersonalInfoViewModel.Name;
            user.Surname = changePersonalInfoViewModel.Surname;
            user.Email = changePersonalInfoViewModel.Email;

            var changePersonalInfoResult = await _userManager.UpdateAsync(user);

            return Ok(changePersonalInfoResult.Succeeded ? true : false);
        }

        [HttpGet("AllUserList")]
        public async Task<IActionResult> GetAllUserList()
        {
            List<ApplicationUser> users = await _userManager.Users.ToListAsync();

            return Ok(users);
        }
    }
}
